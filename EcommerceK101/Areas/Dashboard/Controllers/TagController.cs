using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly AppDbContext _context;


        public TagController(ILogger<TagController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {

            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            var tagExsist = _context.Tags.FirstOrDefault(x => x.Name == tag.Name);
            if (tagExsist != null)
            {
                ViewBag.tagExist = "this Tag    is exist ";
                return View();
            }
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var update = _context.Tags.FirstOrDefault(x => x.Id == id);
            return View(update);

        }

        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            var findTags = _context.Tags.FirstOrDefault(x => x.Name == tag.Name);
            if (findTags != null)
            {
                ViewBag.TagExist = "this Tag is exist ";
                return View();
            }
            var edit = _context.Tags.Update(findTags);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // Tag Delete Get 
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var delete = _context.Tags.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        // Tag Delete 
        [HttpPost]
        public IActionResult Delete(Tag tag)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            // null olub olmamayini baxiriq
            if (!ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            // id var yoxsa yox
            var detailChek = _context.Tags.FirstOrDefault(x => x.Id == id);
            // var products = _context.Products.Where(x => x.Category.Id == detailChek.Id).ToList();
            return View(detailChek);
        }

    }
}