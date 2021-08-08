using ContactInfoSystem.App.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Areas.Users.Controllers
{

    [Area("Users")]
    [CustomAuthorize(Roles = "Manager,CEO,CTO,Developer")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
