using ContactInfoSystem.App.Helpers;
using ContactInfoSystem.App.Models;
using ContactInfoSystem.Models;
using ContactInfoSystem.Repositories;
using ContactInfoSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfoSystem.App.Controllers
{
    public class LoginController : Controller
    {
        public readonly IUnitOfWork _UnitOfWork;
        public readonly IAuthService _authService;
        public readonly IFileHelper _fileHelper;

        public LoginController(IUnitOfWork unitOfWork, IAuthService authService, IFileHelper fileHelper)
        {
            _UnitOfWork = unitOfWork;
            _authService = authService;
            _fileHelper = fileHelper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _authService.AuthenticateUser(model.Username, model.Password);
            if (user != null)
            {
                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Users" });
                }
            }

            return View("Index");
        }

        public IActionResult SignUp()
        {
            BindDropDownForSignUp();
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel userViewModel)
        {
            BindDropDownForSignUp();
            string fileName = string.Empty;
            string errorMessage = string.Empty;
            if (ModelState.IsValid)
            {
                errorMessage = ValidateUser(userViewModel);
                if (string.Equals("pass", errorMessage, StringComparison.OrdinalIgnoreCase))
                {
                    if (userViewModel.File != null)
                    {
                        fileName = _fileHelper.FormatFileName(userViewModel.File);
                    }
                    User user = new User
                    {
                        Name = userViewModel.UserFullName,
                        UserName = userViewModel.EmailAddress,
                        Email = userViewModel.EmailAddress,
                        PhoneNumber = userViewModel.MobileNo,
                        Gender = userViewModel.Gender,
                        CountryId = userViewModel.CountryId,
                        UserImageName = fileName

                    };
                    string role = _UnitOfWork.RoleRepository.Find(userViewModel.DesignationId).NormalizedName;
                    bool result = _authService.CreateUser(user, userViewModel.Password, role);
                    if (result)
                    {
                        if (userViewModel.File != null)
                        {
                            _fileHelper.UploadFile(userViewModel.File, "UserImages", fileName);
                        }
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }
            return View();
        }



        protected string ValidateUser(UserViewModel userViewModel)
        {
            string errorMessage = "Pass";
            if (userViewModel.DesignationId == 0)
            {
                errorMessage = "Please select designation";
            }
            else if (userViewModel.CountryId == 0)
            {
                errorMessage = "Please select country";
            }
            else if (userViewModel.Gender == 0)
            {
                errorMessage = "Please select gender";
            }
            else if (userViewModel.File != null)
            {
                string fileerror = "Pass";
                fileerror = _fileHelper.ValidateFile(2048, new string[] { "image/png", "image/jpeg", "image/jpg" }, userViewModel.File);
                if (!string.Equals("pass", fileerror, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = fileerror;
                }
            }
            return errorMessage;
        }

        protected void BindDropDownForSignUp()
        {
            ViewBag.DesignationList = _UnitOfWork.RoleRepository.GetAll();
            ViewBag.CountryList = _UnitOfWork.CountryRepository.GetAll();
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }



        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}
