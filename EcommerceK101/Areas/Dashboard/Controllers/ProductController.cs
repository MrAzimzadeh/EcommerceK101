
using EcommerceK101.Areas.Dashboard.ViewModels;
using EcommerceK101.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
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
        public IActionResult Create(Product product, IFormFile Photo)
        {
            var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
            var seo_url = SeoUrlHelper.SeoUrl(product.Name);
            product.PhotoUrl = photo;
            product.SeoUrl = seo_url;
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var dele = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(dele);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var detail = _context.Products.FirstOrDefault(x => x.Id == id);

            return View(detail);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var edit = _context.Products.FirstOrDefault(x => x.Id == id);
            var categories = _context.Categories.ToList();

            ProductVM productVm = new()
            {
                Products = edit,
                Categories = categories
            };

            return View(productVm);
        }

        [HttpPost]
        public IActionResult Update(ProductVM productVm, int id, IFormFile Photo)
        {
            // VM gonderende id ile gondermeliyik yoxsa islemir 
            var updateProduct = _context.Products.SingleOrDefault(x => x.Id == id);
            if (Photo != null)
            {
                updateProduct.PhotoUrl = ImageHelper.UploadSinglePhoto(Photo, _env);

            }

            var seo_url = SeoUrlHelper.SeoUrl(productVm.Products.Name);
            updateProduct.SeoUrl = seo_url;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
