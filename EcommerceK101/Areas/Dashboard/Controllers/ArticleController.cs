using System.Security.Claims;
using EcommerceK101.Areas.Dashboard.ViewModels;
using EcommerceK101.Helpers;
using EcommerceK101.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
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

        public IActionResult Index()
        {

            var articles = _context.Articles
                .Include(x => x.User)
                .Include(x => x.ArticleTags).ThenInclude(x => x.Tag)
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
        public async Task<IActionResult> Create(Article article, IFormFile Photo, IFormFile Cover, List<int> tagId)
        {
            var seo_url = SeoUrlHelper.SeoUrl(article.Title);
            article.SeoUrl = seo_url;
            var tagList1 = _context.Tags.ToList();
            ViewBag.Tags = new SelectList(tagList1, "Id", "Name");
            try
            {
                var photo = ImageHelper.UploadSinglePhoto(Photo, _env);
                article.PhotoUrl = photo;
                var cover = ImageHelper.UploadSinglePhoto(Cover, _env);
                article.CoverPhoto = cover;

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
                        ArticleId = article.Id,
                        TagId = tagId[i]
                    };
                    tagList.Add(articleTag);
                }

                article.CreatedDate = DateTime.Now;
                article.UpdatedDate = DateTime.Now;

                await _context.ArticleTags.AddRangeAsync(tagList); // listde Range istifade edirik '
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
                throw;
            }
        }

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var delete = _context.Articles.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(Article article)
        {
            var delete = _context.Articles.FirstOrDefault(x => x.Id == article.Id);
            delete.IsDeleted = true;
            delete.IsActive = false;
            var result = _context.Articles.Update(delete);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            var tags = _context.Tags.ToList();
            ViewData["Tags"] = tags;
            var article = _context.Articles.Include(x => x.ArticleTags).FirstOrDefault(x => x.Id == id);
            return View(article);
        }

        [HttpPost]
        public IActionResult Update(Article article, IFormFile Photo, IFormFile Cover, List<int> Tags)
        {
            try
            {
                article.UpdatedDate = DateTime.Now;
                article.SeoUrl = SeoUrlHelper.SeoUrl(article.Title);
                if (Photo != null)
                    article.PhotoUrl = ImageHelper.UploadSinglePhoto(Photo, _env);
                if (Cover != null)
                {
                    article.CoverPhoto = ImageHelper.UploadSinglePhoto(Cover, _env);
                }
                var oldTags = _context.ArticleTags.Where(x => x.ArticleId == article.Id).ToList();
                _context.ArticleTags.RemoveRange(oldTags);
                _context.SaveChanges();
                List<ArticleTag> tagList = new();
                for (int i = 0; i < Tags.Count; i++)
                {
                    ArticleTag articleTag = new()
                    {
                        ArticleId = article.Id,
                        TagId = Tags[i]
                    };
                    tagList.Add(articleTag);
                }

                // Todo --------  DateTime.now   ---------------
                DateTime createdDate = _context.Articles.AsNoTracking().FirstOrDefault(x => x.Id == article.Id)?.CreatedDate ?? DateTime.MinValue;
                if (createdDate != DateTime.MinValue)
                {
                    article.CreatedDate = createdDate;
                }
                _context.Entry(article).Property(x => x.CreatedDate).IsModified = false;
                //  * -----------------------


                _context.ArticleTags.AddRange(tagList);
                _context.Articles.Update(article);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(article);
            }
        }

        public IActionResult Detail(int id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var check = _context.Articles.Include(X => X.User)
                .Include(x => x.ArticleTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);

            return View(check);

        }





    }
}
