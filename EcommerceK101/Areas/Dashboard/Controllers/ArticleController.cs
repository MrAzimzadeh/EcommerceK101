using System.Security.Claims;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class ArticleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor; //  Istifadecinin Id sini tapir 
        private readonly IWebHostEnvironment _env;

        public ArticleController(AppDbContext context, IHttpContextAccessor contextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _env = env;
        }

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articles = _context.Articles
                .Include(x => x.User)
                .Include(x => x.Tags)
                .ToList();
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var tags = _context.Tags.ToList();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Article article, IFormFile Photo, List<int> tagId)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            article.UserId = userId;
            var tags = _context.Tags.ToList();
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            List<ArticleTag> tagList = new();
            for (int i = 0; i < tagId.Count; i++)
            {
                ArticleTag articleTag = new()
                {
                    ArtcleId = article.Id,
                    TagId = tagId[i]
                };
                tagList.Add(articleTag);
            }

            await _context.ArticleTags.AddRangeAsync(tagList); // listde Range istifade edirik '
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }

    }
}
