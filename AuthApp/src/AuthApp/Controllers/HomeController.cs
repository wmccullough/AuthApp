using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = User.IsInRole("Physicians");

            return View();
        }

        [Authorize]
        public IActionResult Authenticated()
        {
            return View();
        }
    }
}
