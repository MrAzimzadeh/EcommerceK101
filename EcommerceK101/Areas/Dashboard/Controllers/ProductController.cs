using EcommerceK101.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ProductController : Controller
    {
        private  readonly  AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(x =>x.Category).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product , IFormFile Photo)
        {
            var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
            var seo_url = SeoUrlHelper.SeoUrl(product.Name);
            product.PhotoUrl = photo;
            product.SeoUrl = seo_url;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
