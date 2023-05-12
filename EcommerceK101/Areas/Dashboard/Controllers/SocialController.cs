using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class SocialController : Controller
    {
        private readonly AppDbContext _context;

        public SocialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var social = _context.SocialNetworks.ToList();
            return View(social);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var check = _context.SocialNetworks.FirstOrDefault(x => x.Id == id);
            return View(check);
        }

        [HttpPost]
        public IActionResult Delete(SocialNetwork social)
        {
            _context.SocialNetworks.Remove(social);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialNetwork socialNetwork)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(socialNetwork);
                }
                var socialIconChek = _context.SocialNetworks.FirstOrDefault(x => x.Icon == socialNetwork.Icon);
                var SocialUrlCheck = _context.SocialNetworks.FirstOrDefault(x => x.BaseUrl == socialNetwork.BaseUrl);

                if (socialIconChek != null)
                {
                    ViewBag.Icon = "Icon var!";
                    return View();
                }
                else if (SocialUrlCheck != null)
                {
                    ViewBag.Url = "url var!";
                    return View();
                }
                _context.SocialNetworks.Add(socialNetwork);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = "Error";
                return View(socialNetwork);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var check = _context.SocialNetworks.FirstOrDefault(x => x.Id == id);
            ViewBag.iconShow = check.Icon;
            return View(check);
        }
        [HttpPost]
        public IActionResult Edit(SocialNetwork socialNetwork)
        {
            if (!ModelState.IsValid)
            {
                return View(socialNetwork);
            }

            var socialIconChek = _context.SocialNetworks.FirstOrDefault(x => x.Icon == socialNetwork.Icon);
            var SocialUrlCheck = _context.SocialNetworks.FirstOrDefault(x => x.BaseUrl == socialNetwork.BaseUrl);
            ViewBag.iconShow = socialNetwork.Icon;
            if (socialIconChek != null)
            {
                ViewBag.Icon = "Icon var!";
                return View();
            }
            else if (SocialUrlCheck != null)
            {
                ViewBag.Url = "url var!";
                return View();
            }
            _context.SocialNetworks.Update(socialNetwork);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




    }
}
