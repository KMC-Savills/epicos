using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Repository;

namespace EpicOS.Managers
{
    public class UserManager : BaseManager
    {

        private UserRepository user;

        public UserManager()
        {
            this.user = new UserRepository();
        }

        public List<User> GetAll()
        {
            List<User> users = cacheNinja.cache["User_User_GetAll"] as List<User>;
            if (users == null)
            {
                users = user.GetUsers();
                cacheNinja.cache.Set("User_User_GetAll", users, cacheNinja.cacheExpiry);
            }
            return users;
        }

        public User GetByID(int id)
        {
            return GetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public User GetByEmail(string email)
        {
            return GetAll().FirstOrDefault(e => e.EmailAddress.Equals(email) && e.IsActive.Equals(true));
        }

        public User GetByCredentials(string username, string password)
        {
            password = Blitz.CalculateMD5Hash(password);
            return GetAll().FirstOrDefault(e => (e.UserName.Equals(username) || e.EmailAddress.Equals(username)) && e.Password.Equals(password));
        }

        public Result Update(User parameter)
        {
            return user.UpdateUser(parameter);
        }

    }
}
