using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area(nameof(Dashboard))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
