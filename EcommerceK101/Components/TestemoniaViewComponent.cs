using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using EcommerceK101.ViewModels;
using WebApp.Data;

namespace EcommerceK101.Components
{
    public class TestemoniaViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;
        public TestemoniaViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = _context.Contacts.ToList();
            

            // // ViewData["CategoryList"] = viewResult;
            SliderVM homeVm = new SliderVM ()
            {
                Contacts = menu
            };
            
            var viewResult = View(viewName: "Default", model: menu);
            return await Task.FromResult<IViewComponentResult>(viewResult);

        }
    }
}
