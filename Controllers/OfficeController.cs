using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Entities;
using EpicOS.Managers;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers
{
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            List<Office> viewModel = new List<Office>();
            OfficeManager manager = new OfficeManager();
            viewModel = manager.OfficeGetAll();

            return View(viewModel);
        }
    }
}