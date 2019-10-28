using EpicOS.Models.Entities;
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
                        item.IPAddress = row["IPAddress"].ToString();
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
                        item.IPAddress = row["IPAddress"].ToString();
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

        public Result TelemeryInsert(Telemery parameter)
        {
            var result = dbConnection.Insert("usp_Telemery_Insert", parameter);
            return result;
        }

    }
}
