using areas.Areas.Products.Data;
using areas.Areas.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace areas.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductController : Controller
    {
        private static readonly ProductsModel[] Products = new[]
        {
            new ProductsModel { Id = 1, Type="Book", Description="Book1", ManufacturedDate= new DateTime(2022,1,1) },
            new ProductsModel { Id = 2, Type="Book", Description="Book1", ManufacturedDate= new DateTime(2012,1,1) },
            new ProductsModel { Id = 3, Type="Milk", Description="organic milk", ManufacturedDate= new DateTime(2024,1,1) },
            new ProductsModel { Id = 4, Type="Milk", Description="normal milk", ManufacturedDate= new DateTime(2024,2,1) },
            new ProductsModel { Id = 5, Type="Eggs", Description="organic eggs", ManufacturedDate= new DateTime(2024,2,1) },
            new ProductsModel { Id = 6, Type="Eggs", Description="normal eggs", ManufacturedDate= new DateTime(2024,1,1) },
        };

        public IActionResult Index()
        {
            var p = new ProductDTO()
            {
                Product = new ProductsModel(),
                Products = Products.ToList()
            };
            return View(p);
        }

        public IActionResult GetProduct(int id)
        {
            return View(Products.FirstOrDefault(p=>p.Id==id));
        }
    }
}
