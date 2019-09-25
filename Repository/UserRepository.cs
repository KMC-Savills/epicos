using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models;
using EpicOS.Models.Entities;

namespace EpicOS.Repository
{
    public class UserRepository : BaseRepository
    {

        /// <summary>
        /// Gets all User from stored procedure
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            var result = new List<User>();

            var reader = dbConnection.Select("usp_GetUsers", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        User item = new User();
                        item.ID = transform.ToInt(row["ID"]);
                        item.FirstName = row["FirstName"].ToString();
                        item.LastName = row["LastName"].ToString();
                        item.UserName = row["UserName"].ToString();
                        item.Password = row["Password"].ToString();
                        item.CompanyID = transform.ToInt(row["CompanyID"]);
                        item.Phone = row["Phone"].ToString();
                        item.EmailAddress = row["EmailAddress"].ToString();
                        item.RoleID = transform.ToInt(row["RoleID"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);                        
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Result UpdateUser(User parameter)
        {
            var result = dbConnection.Update("usp_UpdateUser", parameter);
            return result;
        }

    }
}
