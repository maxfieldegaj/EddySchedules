using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eddy.UI.Controllers
{
    public class ManagerController : Controller
    {
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Requests()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Availability()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}