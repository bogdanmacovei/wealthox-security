using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wealthox.Entities;
using Wealthox.Entities.DTOs;
using Wealthox.Services;
using Wealthox.Web.Code.Base;
using Wealthox.Web.Models.Account;

namespace Wealthox.Web.Controllers
{
    public class UserAccountController : BaseController
    {
        private readonly UserAccountService userAccountService;
        private readonly CurrentUser currentUser;
        public UserAccountController(UserAccountService userAccountService, CurrentUser currentUser, IMapper mapper)
            : base(mapper)
        {
            this.userAccountService = userAccountService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public IActionResult GetUserById(Guid id)
        {
            var user = userAccountService.GetUserById(id);
            return Json(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginVm();
            if (currentUser.IsAuthenticated)
                return RedirectToAction("Index", "Announcement");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userAccountService.Login(model.Email, model.Password);
            if (user == null)
            {
                model.AreCredentialsInvalid = true;

                return View(model);
            }

            await LogIn(user);

            return RedirectToAction("Index", "Announcement");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await LogOut();

            return RedirectToAction("Login", "UserAccount");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (currentUser.IsAuthenticated)
            {
                return RedirectToAction("Index", "Announcement");
            }
            var model = new RegisterVm
            {
                //Counties = GetCounties(),
                DateOfBirth = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterVm model)
        {
            if (!ModelState.IsValid)
            {
                //model.Counties = GetCounties();

                return View(model);
            }

            var entity = mapper.Map<Users>(model);

            var result = userAccountService.Register(entity);
            if (!result)
                return InternalServerErrorView();

            return RedirectToAction("Login", "UserAccount");
        }

        [HttpGet]
        public IActionResult IsEmailAvailable(string Email)
        {
            var emailExists = userAccountService.EmailExists(Email);

            return Ok(!emailExists);
        }

        public async Task LogIn(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
            };
    
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                    scheme: "WealthoxCookies",
                    principal: principal);
        }

        private async Task LogOut()
        {
            await HttpContext.SignOutAsync(scheme: "WealthoxCookies");
        }
    }
}
