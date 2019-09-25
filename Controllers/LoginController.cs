using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EpicOS.Managers;
using EpicOS.Models;
using EpicOS.Models.Entities;

namespace EpicOS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.LoginContext = "0";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel parameter, string ReturnUrl = "/")
        {
            ViewBag.LoginContext = "2";
            if (ModelState.IsValid)
            {
                UserManager manager = new UserManager();
                User user = manager.GetByCredentials(parameter.Username, parameter.Password);
                if (user != null)
                {
                    if (user.IsActive == true)
                    {
                        HttpContext.Session.SetInt32("UserID", user.ID);
                        HttpContext.Session.SetInt32("RoleID", user.RoleID);
                        ViewBag.LoginContext = "1";
                        return Redirect(ReturnUrl);
                    }
                }
            }
            return View(parameter);
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("RoleID");
            return Redirect("/login");
        }

    }
}