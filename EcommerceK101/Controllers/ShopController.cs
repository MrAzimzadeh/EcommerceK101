using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace EcommerceK101.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;

        private readonly AppDbContext _context;
        public ShopController(ILogger<ShopController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var shopList = _context.Products.Include(x=>x.Category).OrderByDescending(x=>x.Id).ToList();
            var category = _context.Categories.OrderByDescending(x=>x.Id).ToList();
            ShopVM vm = new ShopVM()
            {
                Categories = category, 
                Products = shopList
            };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}