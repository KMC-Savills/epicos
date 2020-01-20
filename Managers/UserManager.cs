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

        private UserRepository userRepository;

        public UserManager()
        {
            this.userRepository = new UserRepository();
        }

        public List<User> GetAll()
        {
            List<User> users = cacheNinja.cache["User_GetAll"] as List<User>;
            if (users == null)
            {
                users = userRepository.GetUsers();
                cacheNinja.cache.Set("User_GetAll", users, cacheNinja.cacheExpiry);
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

        public Result Insert(User parameter)
        {
            return userRepository.Insert(parameter);
        }

        public Result Update(User parameter)
        {
            return userRepository.Update(parameter);
        }
        public Result Delete(int id)
        {
            User item = userRepository.GetByID(id);
            item.IsDeleted = true;
            Result result = userRepository.Update(item);
            if (result.IsSuccess)
            {
                cacheNinja.ClearCache("Office_GetAll");
            }

            return result;
        }
    }
}
