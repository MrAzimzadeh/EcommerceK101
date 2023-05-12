using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class TeaamController : Controller
    {
        private readonly AppDbContext _context;

        public TeaamController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Teams.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            try
            {
                var social = _context.SocialNetworks.ToList();
                ViewData["socials"] = social;
                return View();

            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Team team  , IFormFile Photo)
        {
            var social = _context.SocialNetworks.ToList();
            ViewBag.social = new SelectList(social, "Id", "Icon");


            return RedirectToAction();
        }

    }
}
