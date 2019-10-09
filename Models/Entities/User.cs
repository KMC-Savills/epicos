using EpicOS.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Models.Entities
{
    public class User
    {

        public User()
        {

        }

        public User(int id)
        {
            UserManager manager = new UserManager();
            var user = manager.GetByID(id);
            this.ID = user.ID;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.CompanyID = user.CompanyID;
            this.Phone = user.Phone;
            this.EmailAddress = user.EmailAddress;
            this.RoleID = user.RoleID;
            this.IsActive = user.IsActive;
            this.IsDeleted = user.IsDeleted;
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public Result Create()
        {
            UserManager manager = new UserManager();
            return manager.Insert(this);
        }

        public Result Save()
        {
            UserManager manager = new UserManager();
            return manager.Update(this);
        }

    }
}
