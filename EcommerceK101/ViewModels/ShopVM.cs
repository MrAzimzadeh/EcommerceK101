using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.Models;

namespace EcommerceK101.ViewModels
{
    public class ShopVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}