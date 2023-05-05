using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace EcommerceK101.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly AppDbContext _context;
        public CategoryController(ILogger<CategoryController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult CategoryList(int id)
        {
            var category = _context.Products
                .Include(c => c.Category).Where(x=>x.CategoryId == id)
                .ToList();
            ViewData["CategoryName"] = category;
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}