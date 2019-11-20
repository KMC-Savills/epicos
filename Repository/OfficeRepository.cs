using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Entities;

namespace EpicOS.Repository
{
    public class OfficeRepository : BaseRepository
    {

        public List<Office> GetAll()
        {
            List<Office> result = new List<Office>();
            var reader = dbConnection.Select("usp_Office_GetAll");
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Office item = new Office();
                        item.ID = transform.ToInt(row["ID"]);
                        item.Name = row["Name"].ToString();
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Result Insert(User parameter)
        {
            var result = dbConnection.Insert("usp_Office_Insert", parameter);
            return result;
        }

        public Result Update(User parameter)
        {
            var result = dbConnection.Update("usp_Office_Update", parameter);
            return result;
        }

    }
}
