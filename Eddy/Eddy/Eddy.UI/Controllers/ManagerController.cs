using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eddy.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eddy.UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseController
    {
        public ManagerController(UserManager<ApplicationUser> userManager) : base(userManager)
        {
        }

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