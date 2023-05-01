using EcommerceK101.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Controllers
{
    public class ArticleController : Controller
    {
        private  readonly  AppDbContext _context;

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var article = _context.Articles.Include(X=>X.User).Include(x=>x.ArticleTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id);
            ArticleDetailVM VM = new ArticleDetailVM()
            {
                Article = article
            };

            return View(VM);
        }
    }
}
