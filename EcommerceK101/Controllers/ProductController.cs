using EcommerceK101.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Controllers
{
    public class ProductController : Controller
    {
        private  readonly  AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Detail(int? id)
        {
            var product = _context.Products.Include(x=>x.Category).SingleOrDefault(x=>x.Id == id);
            var cat = product.CategoryId;

            var artCreate = _context.Products.Where(x=>x.CategoryId == cat && x.Id != id).Take(3).ToList();



            ProductDetailVM vm = new ProductDetailVM()
            {
                Product = product,
                Products = artCreate
            };

            return View(vm);
        }
    }
}
