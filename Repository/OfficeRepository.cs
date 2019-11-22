using EpicOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Repository
{
    public class OfficeRepository : BaseRepository
    {

        public List<Office> OfficeGetAll()
        {
            List<Office> result = new List<Office>();

            var reader = dbConnection.Select("usp_Office_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Office item = new Office();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        item.Address = row["Address"].ToString();
                        item.CityID = transform.ToInt(row["CityID"]);
                        item.Latitude = transform.ToDouble(row["Latitude"]);
                        item.Longitude = transform.ToDouble(row["Longitude"]);
                        item.Filename = row["Filename"].ToString();
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        internal List<Floor> FloorGetAll()
        {
            List<Floor> result = new List<Floor>();

            var reader = dbConnection.Select("usp_Floor_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Floor item = new Floor();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        item.Filename = row["Filename"].ToString();
                        item.Type = transform.ToInt(row["Type"]);
                        item.OfficeID = transform.ToInt(row["OfficeID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        internal List<Company> CompanyGetAll() 
        {
            List<Company> result = new List<Company>();

            var reader = dbConnection.Select("usp_Company_GetAll", null, CommandType.StoredProcedure);
            if (reader != null) 
            {
                if (reader.Rows.Count > 0) 
                {
                    foreach (DataRow row in reader.Rows) 
                    {
                        Company item = new Company();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Office OfficeGetByID(int ID)
        {
            Office item = new Office();

            object parameter = new Office()
            {
                ID = ID
            };
            var reader = dbConnection.Select("usp_Office_GetByID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    item.ID = ID;
                    item.Name = reader.Rows[0]["Name"].ToString();
                    item.Address = reader.Rows[0]["Address"].ToString();
                    item.CityID = transform.ToInt(reader.Rows[0]["CityID"]);
                    item.Latitude = transform.ToDouble(reader.Rows[0]["Latitude"]);
                    item.Longitude = transform.ToDouble(reader.Rows[0]["Longitude"]);
                    item.Filename = reader.Rows[0]["Filename"].ToString();
                    item.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    item.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);
                }
            }
            return item;
        }

        public Result OfficeInsert(Office parameter)
        {
            var result = dbConnection.Insert("usp_Office_Insert", parameter);
            return result;
        }

        public Result OfficeUpdate(Office parameter)
        {
            var result = dbConnection.Update("usp_Office_Update", parameter);
            return result;
        }

        public Floor FloorGetByOfficeId(int ID)
        {
            Floor item = new Floor();

            object parameter = new Floor()
            {
                ID = ID
            };
            var reader = dbConnection.Select("usp_Floor_GetByOfficeID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    item.ID = ID;
                    item.Name = reader.Rows[0]["Name"].ToString();
                    item.Filename = reader.Rows[0]["Filename"].ToString();
                    item.Type = transform.ToInt(reader.Rows[0]["Type"]);
                    item.OfficeID = transform.ToInt(reader.Rows[0]["OfficeID"]);
                    item.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    item.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);
                }
            }
            return item;
        }

        public Result FloorInsert(Floor parameter)
        {
            var result = dbConnection.Insert("usp_Floor_Insert", parameter);
            return result;
        }

        public Result FloorUpdate(Floor parameter)
        {
            var result = dbConnection.Update("usp_Floor_Update", parameter);
            return result;
        }


        public Company CompanyGetByID(int ID)
        {
            Company item = new Company();

            object parameter = new Company()
            {
                ID = ID
            };
            var reader = dbConnection.Select("usp_Company_GetByID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    item.ID = ID;
                    item.Name = reader.Rows[0]["Name"].ToString();
                    item.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    item.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);
                }
            }
            return item;
        }

        public Result CompanyInsert(Company parameter) 
        {
            var result = dbConnection.Insert("usp_Company_Insert", parameter);
            return result;
        }

        public Result CompanyUpdate(Company parameter) 
        {
            var result = dbConnection.Update("usp_Company_Update", parameter);
            return result;
        }
    }
}
