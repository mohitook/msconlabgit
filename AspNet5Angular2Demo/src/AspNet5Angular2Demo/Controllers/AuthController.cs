using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNet5Angular2Demo.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNet5Angular2Demo.Controllers
{
    public class AuthController : Controller
    {
        //belépést nyilvántartó változó
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) //az általunk megadott kényszereket ellenőrzi
            {
                //sikerült-e bejelentkezni?
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                ModelState.AddModelError("", "Username or Password is incorrect");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return Redirect("/");
        }
    }
}
