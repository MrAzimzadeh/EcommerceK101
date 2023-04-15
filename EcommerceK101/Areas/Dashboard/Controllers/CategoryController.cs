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
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var catList = _context.Categories.ToList();
            return View(catList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var findCategory = _context.Categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
            if (findCategory != null)
            {
                ViewBag.CategoryExist = "this Category is exist ";
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var delete = _context.Categories.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var update = _context.Categories.FirstOrDefault(x => x.Id == id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            var findCategory = _context.Categories.FirstOrDefault(x => x.CategoryName == category.CategoryName);
            if (findCategory != null)
            {
                ViewBag.CategoryExist = "this Category is exist ";
                return View();
            }
            var edit = _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}