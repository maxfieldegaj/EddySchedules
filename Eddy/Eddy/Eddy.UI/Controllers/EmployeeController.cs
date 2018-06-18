﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eddy.UI.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : BaseController
    {
        private IShiftServices _shiftServices;
        private IMessageServices _messageServices;
        private IManagerServices _managerServices;
        private IEmployeeServices _employeeServices;
        private IBusinessServices _businessServices;
        private IHostingEnvironment _environment;   

        public EmployeeController(IShiftServices shiftServices,
            IMessageServices messageServices,
            IManagerServices managerServices,
            IEmployeeServices employeeServices,
            IBusinessServices businessServices,
            IHostingEnvironment environment,
            UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _shiftServices = shiftServices;
            _businessServices = businessServices;
            _messageServices = messageServices;
            _managerServices = managerServices;
            _employeeServices = employeeServices;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FirstLogin()
        {
            return View();
        }

        public IActionResult CreateEmployee(Employee newEmployee)
        {


            return RedirectToAction("Index");
        }
        public IActionResult Auction()
        {
            return View();
        }

        public IActionResult Availability()
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

        public IActionResult Settings()
        {
            return View();
        }
    }
}