using ContactInfoSystem.App.Helpers;
using ContactInfoSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Areas.Admin.Controllers
{

    [Area("Admin")]
    [CustomAuthorize(Roles = "Admin")]
    public class DashboardController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int page, int pageSize)
        {
            pageSize = pageSize == 0 ? 10 : pageSize;
            page = page == 0 ? 1 : page;
            var users = _unitOfWork.UserRepository.GetUsers(page, pageSize);
            return View(users);
        }
    }
}
