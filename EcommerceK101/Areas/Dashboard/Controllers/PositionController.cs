using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var position = _context.Positions.ToList();
            ViewBag.count = position.Count;
            return View(position);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(position);
                }

                var check = _context.Positions.FirstOrDefault(x => x.PositionName == position.PositionName);
                if (check != null)
                {
                    ViewBag.Error = $"{check.PositionName} : var";
                    return View(position);
                }
                _context.Positions.Add(position);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var check = _context.Positions.FirstOrDefault(x => x.Id == id);
            return View(check);
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View(position);
            }
            var check = _context.Positions.FirstOrDefault(x => x.PositionName == position.PositionName);
            if (check != null)
            {
                ViewBag.Error = $"{check.PositionName} : var";
                return View(position);
            }
            _context.Positions.Update(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var check = _context.Positions.FirstOrDefault(x => x.Id == id);
            return View(check);
        }

        [HttpPost]
        public IActionResult Delete(Position position)
        {
            _context.Positions.Remove(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





    }
}
