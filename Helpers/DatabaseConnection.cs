using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using EpicOS.Models;
using EpicOS.Models.Entities;

namespace EpicOS.Helpers
{
    public class DatabaseConnection
    {

        private string connectionString = "";

        public DatabaseConnection()
        {
            //this.connectionString = "data source=SUNL-1GT8NV2\\CHAOS;initial catalog=EpicOS;user id=sa;password=Love2eat;";
            this.connectionString = "Data Source= localhost;Initial Catalog=EpicOS;user=sa;password=8Waystop";
        }

        public Result Insert(string _query, Object entityParameter = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = new Result();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(_query);
                    command.Connection = connection;
                    command.CommandType = commandType;
                    if (commandType == CommandType.StoredProcedure)
                    {
                        if (entityParameter != null)
                        {
                            var sqlParameters = GenerateSQLParameters(_query, entityParameter);
                            command.Parameters.AddRange(sqlParameters.ToArray());
                        }
                    }
                    dataAdapter.InsertCommand = command;
                    result.ID = Convert.ToInt32(command.ExecuteScalar());

                    if (result.ID != 0)
                    {
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.IsSuccess = false;
                    }
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Exception = ex;
                    result.ExceptionMessage = ex.ToString();
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        public Result Update(string _query, Object entityParameter = null, CommandType commandType = CommandType.StoredProcedure)
        {
            var result = new Result();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(_query);
                    command.Connection = connection;
                    command.CommandType = commandType;
                    if (commandType == CommandType.StoredProcedure)
                    {
                        if (entityParameter != null)
                        {
                            var sqlParameters = GenerateSQLParameters(_query, entityParameter);
                            command.Parameters.AddRange(sqlParameters.ToArray());
                        }
                    }
                    dataAdapter.UpdateCommand = command;
                    command.ExecuteNonQuery();
                    result.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Exception = ex;
                    result.ExceptionMessage = ex.ToString();
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }

        public DataTable Select(string _query, Object entityParameter = null, CommandType commandType = CommandType.StoredProcedure)
        {
            DataTable dataTable = new DataTable();
            dataTable = null;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(_query);
                    command.Connection = connection;
                    command.CommandType = commandType;
                    if (commandType == CommandType.StoredProcedure)
                    {
                        if (entityParameter != null)
                        {
                            var sqlParameters = GenerateSQLParameters(_query, entityParameter);
                            command.Parameters.AddRange(sqlParameters.ToArray());
                        }
                    }
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
                catch (Exception error)
                {
                    dataTable = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public DataTable GetAllStoredProcedureParameters(string SPName)
        {
            DataTable dataTable = new DataTable();
            dataTable = null;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select * from information_schema.parameters where specific_name='" + SPName + "'");
                    command.Connection = connection;
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(ds);
                    dataTable = ds.Tables[0];
                }
                catch
                {

                }
                finally
                {
                    connection.Close();
                }
            }
            return dataTable;
        }

        public List<SqlParameter> GenerateSQLParameters(string SPName, Object Class)
        {
            var storedProcDatatable = GetAllStoredProcedureParameters(SPName);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (storedProcDatatable != null)
            {
                if (storedProcDatatable.Rows.Count > 0)
                {
                    foreach (DataRow item in storedProcDatatable.Rows)
                    {
                        string parameter = item["PARAMETER_NAME"].ToString();
                        var propertyValue = Class.GetType().GetProperty(parameter.Remove(0, 1)).GetValue(Class, null);
                        sqlParameters.Add(new SqlParameter(parameter, propertyValue));
                    }
                }
            }
            return sqlParameters;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}
