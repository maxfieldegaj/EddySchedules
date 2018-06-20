using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using Eddy.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eddy.UI.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : BaseController
    {
        private IShiftServices _shiftServices;
        private IMessageServices _messageServices;
        private IManagerServices _managerServices;
        private IEmployeeServices _employeeServices;
        private IBusinessServices _businessServices;
        private IHostingEnvironment _environment;

        public ManagerController(IShiftServices shiftServices,
            IMessageServices messageServices,
            IBusinessServices businessServices,
            IManagerServices managerServices,
            IEmployeeServices employeeServices,
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

        private string GetUserId()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims.ToList();

            return claims[0].Value;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var manager = await GetApplicationUser();
            var model = new ManagerScheduleViewModel();
            
            model.Manager = manager;
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ManagerScheduleViewModel viewModel)
        {
            var newSchedule = viewModel.Person.Schedule;
            viewModel.VisibleSchedule = newSchedule;
            return View(viewModel);
        }
        

        public IActionResult FirstLogin()
        {
            return View();
        }

        public IActionResult CreateManager(Manager newManager)
        {

            return RedirectToAction("Index");
        }

        public IActionResult Requests()
        {
            return View();
        }

        public IActionResult Messages()
        {
            return View();
        }

        public async Task<IActionResult> Contacts()
        {
            var user = await GetApplicationUser();
            var model = new ContactsViewModel();
            var biz = _employeeServices.GetSingleEmployeeById(user.Id).PlaceOfBusiness;

            model.PlaceOfBusiness = biz;

            return View(model);
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