using EpicOS.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

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
        [Required(ErrorMessage = "Firstname is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "Mobile/Telephone number is required!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email Address is required!")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Role is required!")]
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
