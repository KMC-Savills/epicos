using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers
{
    public class FloorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Assign()
        {
            return View();
        }

        public IActionResult Monitor()
        {
            return View();
        }

    }
}