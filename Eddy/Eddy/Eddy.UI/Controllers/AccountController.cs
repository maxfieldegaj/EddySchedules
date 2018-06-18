using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eddy.Domain.Models;
using Eddy.Services.Interfaces;
using Eddy.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eddy.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            _roles = _roleManager.Roles.ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel
            {
                Roles = new SelectList(_roles)
            };


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            //check if information is correct
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Email,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName
                };

                var result = await _userManager.CreateAsync(newUser, viewModel.Password);

                if (result.Succeeded) //if user was created
                {

                    result = await _userManager.AddToRoleAsync(newUser, viewModel.Role);

                    if (result.Succeeded)
                    {
                        // auto log in the new user
                        await _signInManager.SignInAsync(newUser, false);


                        if (viewModel.Role == "Employee")
                        {
                            return RedirectToAction("FirstLogin", "Employee");
                        }

                        if (viewModel.Role == "Manager")
                        {

                            return RedirectToAction("FirstLogin", "Manager");
                        }
                    }

                }
                else // try to create user, but it failed 
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            viewModel.Roles = new SelectList(_roles);
            return View(viewModel);
        }

        //URL : Account/Login
        [HttpGet]
        public IActionResult Login() => View();

        // submit the form
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded) // Credentials are correct
                {
                    var user = await _userManager.FindByEmailAsync(viewModel.Email);
                    var isManager = await _userManager.IsInRoleAsync(user, "Manager");
                    var isEmployee = await _userManager.IsInRoleAsync(user, "Employee");

                    if (isManager)
                    {
                        if (user.Verified)
                        {
                            return RedirectToAction("Index", "Manager");
                        }
                        else
                        {
                            return RedirectToAction("FirstLogin", "Manager");
                        }
                    }
                    if (isEmployee)
                    {
                        if (user.Verified)
                        {
                            return RedirectToAction("Index", "Employee");
                        }
                        else
                        {
                            return RedirectToAction("FirstLogin", "Employee");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Invalid");
                }
            }
            return View(viewModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}