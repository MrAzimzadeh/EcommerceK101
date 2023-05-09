using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace EcommerceK101.Controllers
{

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
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contact);
                }
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}