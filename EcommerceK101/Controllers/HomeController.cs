using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EcommerceK101.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger , AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(x=>x.Id).Take(3).ToList();
            var articles = _context.Articles.Include(x=>x.User).Where(x=>x.IsActive == true && x.IsDeleted == false).ToList();
            HomeVM vm = new HomeVM()
            {
                Articles = articles,
                Products = products,

            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}