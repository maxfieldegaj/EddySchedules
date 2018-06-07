using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Max.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaxEd.UI.Controllers
{
    public class BaseController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetApplicationUser()
        {
            return await _userManager.GetUserAsync(User);
        }
    }
}
