using EcommerceK101.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace EcommerceK101.Components
{
    public class LogoViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public LogoViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logo = _context.Companies.ToList();


            // // ViewData["CategoryList"] = viewResult;
            LogoVM logoVM = new LogoVM()
            {
                Companies= logo
            };

            var viewResult = View(viewName: "Default", model: logo);
            return await Task.FromResult<IViewComponentResult>(viewResult);

        }
    }
}
