using EcommerceK101.Helpers;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CompanyController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var list = _context.Companies.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company compony, IFormFile Photo)
        {
            var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
            compony.Logo = photo;
            _context.Companies.Add(compony);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var check = _context.Companies.FirstOrDefault(x => x.Id == id);
            return View(check);
        }
        [HttpPost]
        public IActionResult Delete(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
