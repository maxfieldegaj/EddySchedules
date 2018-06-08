using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eddy.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eddy.UI.Controllers
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
