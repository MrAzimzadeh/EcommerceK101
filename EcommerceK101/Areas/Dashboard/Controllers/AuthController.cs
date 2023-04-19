using EcommerceK101.Areas.DTOs;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class  AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManger;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManger)
        {
            _userManager = userManager;
            _signInManger = signInManger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO logindto)
        {
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerdto)
        {
            User newUser = new()
            {
                Name = registerdto.Name,
                Email = registerdto.Email,
                SurName = registerdto.Surname,
                UserName = registerdto.Email ,
                PhotoUrl = "/img/avatar.png"
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerdto.Password);
            //
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(registerdto);

        }



    }
}
