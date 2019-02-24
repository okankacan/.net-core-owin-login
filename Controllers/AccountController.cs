using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreOwin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreOwin.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [IgnoreAttribute]
        public IActionResult Login()
        {
            return View();
        }


        [IgnoreAttribute]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                await signInManager.SignOutAsync();
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    var userId = "token-"+ user.Id.ToString();
               
                   HttpContext.Session.Set("token", Encoding.UTF8.GetBytes(userId));

                    return RedirectToAction("Index", "Home");
                }

            }


            return View(model);
        }

        [IgnoreAttribute]
        public IActionResult NewUsers()
        {

            return View();
        }


        [IgnoreAttribute]
        [HttpPost]
        public async Task<IActionResult> NewUsers(NewUserModel model)
        {
            if (ModelState.IsValid)
            {

                var _aplicationUser = new ApplicationUser
                {
                    Email = model.Emails,
                    Name = model.Name,
                    SurName = model.SurName,
                    PhoneNumber = model.Phone,
                    UserName = model.UserName

                };
                var result = await userManager.CreateAsync(_aplicationUser, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }



            return View(model);
        }
    }
}