using EcommerceK101.Areas.DTOs;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class AuthController : Controller
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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid) //todo = Bosluqu Yoxlayiriq
            {
                return View(loginDTO);
            }

            var checkEmail = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (checkEmail == null)
            {
                ViewBag.Error = "This Email Is not exist! "; // 
                return View();
            }

            Microsoft
                .AspNetCore
                .Identity
                .SignInResult
                result =
                    await _signInManger
                        .PasswordSignInAsync(
                            checkEmail,
                            loginDTO.Password,
                            isPersistent: loginDTO.RememberMe,
                            lockoutOnFailure: true
                        );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Error", "Email or Password is invalid!!!");
                return View();
            }

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
                UserName = registerdto.Email,
                PhotoUrl = "/img/avatar.png"
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerdto.Password);
            //
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            return View(registerdto);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}