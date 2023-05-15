using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
  [Area("Dashboard")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly AppDbContext _context;

        public ContactController(ILogger<ContactController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var contact = _context.Contacts.ToList();
            return View(contact);
        }

        public IActionResult Detail(int id)
        {
            var editDetail = _context.Contacts.FirstOrDefault(x => x.Id == id);
            return View(editDetail);
        }

        [HttpPost]
        public IActionResult Detail(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}