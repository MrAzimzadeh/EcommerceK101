using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
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

        public IActionResult Details(int id)
        {
            return View();
        }

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

                _context.SocialNetworks.Add(socialNetwork);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                ViewBag.Error = "aLINMADAI ";
                return View(socialNetwork);
            }

        }

    }
}
