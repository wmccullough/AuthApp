using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthApp.Models;
using System.Security.Claims;

namespace AuthApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = User.IsInRole("Physicians");
            UserViewModel model;

            if (User.Identity.IsAuthenticated)
            {
                model = new UserViewModel()
                {
                    User = User,
                    FirstName = User.FindFirst(ClaimTypes.GivenName).Value,
                    LastName = User.FindFirst(ClaimTypes.Surname).Value
                };
            }else
            {
                model = new UserViewModel()
                {
                    User = User,
                    FirstName = string.Empty
                };
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Authenticated()
        {
            return View();
        }
    }
}
