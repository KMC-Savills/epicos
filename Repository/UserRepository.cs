using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models;
using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Identity;

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

            var reader = dbConnection.Select("usp_User_GetAll", null, CommandType.StoredProcedure);
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

        public Result Insert(User parameter)
        {
            var result = dbConnection.Insert("usp_User_Insert", parameter);
            return result;
        }

        public Result Update(User parameter)
        {
            var result = dbConnection.Update("usp_User_Update", parameter);
            return result;
        }
        public User GetByID(int id)
        {
            User users = new User();

            object parameter = new User()
            {
                ID = id
            };
            var reader = dbConnection.Select("usp_User_GetByID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    users.ID = id;
                    users.FirstName = reader.Rows[0]["FirstName"].ToString();
                    users.LastName = reader.Rows[0]["LastName"].ToString();
                    users.Password = reader.Rows[0]["Password"].ToString();
                    users.CompanyID = transform.ToInt(reader.Rows[0]["CompanyID"]);
                    users.Phone = reader.Rows[0]["Phone"].ToString();
                    users.EmailAddress = reader.Rows[0]["EmailAddress"].ToString();
                    users.RoleID = transform.ToInt(reader.Rows[0]["RoleID"]);
                    users.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    users.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);

                }
            }
            return users;
        }
    }

}
