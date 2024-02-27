using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using routing.Models;

namespace routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
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

        [HttpGet]
        [Route("GetProducts")]
        public IEnumerable<ProductsModel> Get()
        {
            return Products.Take(Random.Shared.Next(Products.Length));
        }

        [HttpGet]
        [Route("GetProduct/{id?}")]
        public ProductsModel GetProduct(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
