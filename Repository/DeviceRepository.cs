using EpicOS.Models.Entities;
using EpicOS.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Repository
{
    public class DeviceRepository : BaseRepository
    {

        public List<Workpoint> WorkpointGetAll()
        {
            var result = new List<Workpoint>();

            var reader = dbConnection.Select("usp_Workpoint_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Workpoint item = new Workpoint();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        item.MAC = row["MAC"].ToString();
                        item.IPaddress = row["IPAddress"].ToString();
                        item.CoordinateX = transform.ToDouble(row["CoordinateX"]);
                        item.CoordinateY = transform.ToDouble(row["CoordinateY"]);
                        item.CoordinateZ = transform.ToDouble(row["CoordinateZ"]);
                        item.OfficeID = transform.ToInt(row["OfficeID"]);
                        item.FloorID = transform.ToInt(row["FloorID"]);
                        item.RoomID = transform.ToInt(row["RoomID"]);
                        item.HubID = transform.ToInt(row["HubID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        internal List<Hub> HubGetAll()
        {
            var result = new List<Hub>();

            var reader = dbConnection.Select("usp_Hub_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Hub item = new Hub();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        item.MAC = row["MAC"].ToString();
                        item.IPaddress = row["IPAddress"].ToString();
                        item.OfficeID = transform.ToInt(row["OfficeID"]);
                        item.FloorID = transform.ToInt(row["FloorID"]);
                        item.RoomID = transform.ToInt(row["RoomID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        internal List<Telemery> TelemeryGetAll() 
        {
            var result = new List<Telemery>();

            var reader = dbConnection.Select("usp_Telemetry_GetAll", null, CommandType.StoredProcedure);
            if (reader != null) 
            {
                if (reader.Rows.Count > 0) 
                {
                    foreach (DataRow row in reader.Rows) 
                    {
                        Telemery item = new Telemery();
                        item.ID = transform.ToInt(row["ID"]);
                        item.MAC = row["MAC"].ToString();
                        item.IPAddress = row["IPAddress"].ToString();
                        item.DateCreated = transform.ToDateTime(row["DateCreated"]);
                        item.Battery = row["Battery"].ToString();
                        item.HubID = transform.ToInt(row["HubID"]);
                        item.WorkpointID = transform.ToInt(row["WorkpointID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        internal List<Telemery> TelemeryGetFilter(TelemeryFilter parameter)
        {
            var result = new List<Telemery>();

            var reader = dbConnection.Select("usp_Telemery_GetFilter", parameter, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Telemery item = new Telemery();
                        item.ID = transform.ToInt(row["ID"]);
                        item.MAC = row["MAC"].ToString();
                        item.IPAddress = row["IPAddress"].ToString();
                        item.DateCreated = transform.ToDateTime(row["DateCreated"]);
                        item.Battery = row["Battery"].ToString();
                        item.HubID = transform.ToInt(row["HubID"]);
                        item.WorkpointID = transform.ToInt(row["WorkpointID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Hub GetByID(int ID)
        {
            Hub item = new Hub();

            object parameter = new Hub()
            {
                ID = ID
            };
            var reader = dbConnection.Select("usp_Hub_GetByID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    item.ID = ID;
                    item.Name = reader.Rows[0]["Name"].ToString();
                    item.DeviceType = transform.ToInt(reader.Rows[0]["DeviceType"]);
                    item.MAC = reader.Rows[0]["Type"].ToString();
                    item.IPaddress = reader.Rows[0]["OfficeID"].ToString();
                    item.OfficeID = transform.ToInt(reader.Rows[0]["OfficeID"]);
                    item.RoomID = transform.ToInt(reader.Rows[0]["RoomID"]);
                    item.FloorID = transform.ToInt(reader.Rows[0]["FloorID"]);
                    item.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    item.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);
                }
            }
            return item;
        }

        public Result WorkpointInsert(Workpoint parameter)
        {
            var result = dbConnection.Insert("usp_Workpoint_Insert", parameter);
            return result;
        }

        public Result WorkpointUpdate(Workpoint parameter)
        {
            var result = dbConnection.Update("usp_Workpoint_Update", parameter);
            return result;
        }

        public Result HubInsert(Hub parameter)
        {
            var result = dbConnection.Insert("usp_Hub_INSERT", parameter);
            return result;
        }

        public Result HubUpdate(Hub parameter)
        {
            var result = dbConnection.Update("usp_Hub_Update", parameter);
            return result;
        }

        public Result TelemeryInsert(Telemery parameter)
        {
            var result = dbConnection.Insert("usp_Telemery_Insert", parameter);
            return result;
        }

        public Result TelemeryUpdate(Telemery parameter)
        {
            var result = dbConnection.Update("usp_Telemery_Update", parameter);
            return result;
        }
    }
}
