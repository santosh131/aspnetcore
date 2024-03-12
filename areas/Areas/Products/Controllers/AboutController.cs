using Microsoft.AspNetCore.Mvc;

namespace areas.Areas.Products.Controllers
{
    [Area("Products")]
    public class AboutController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
