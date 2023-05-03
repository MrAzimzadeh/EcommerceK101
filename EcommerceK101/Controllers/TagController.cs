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

    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly AppDbContext _context;

        public TagController(ILogger<TagController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult TagList(int id)
        {
            var tags = _context.Tags
               .Include(c => c.ArticleTags)
               .ThenInclude(x => x.Article).ThenInclude(x=>x.User)
               .FirstOrDefault(c => c.Id == id);

            ViewData["TagName"] = tags.Name;
            ViewData["TagId"] = tags.Id;

            return View(tags.ArticleTags);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}