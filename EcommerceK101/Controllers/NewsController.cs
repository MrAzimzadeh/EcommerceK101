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
 
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly AppDbContext _context;

        public NewsController(ILogger<NewsController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var news = _context.Articles.Include(x=>x.User).ToList();
            return View(news);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}