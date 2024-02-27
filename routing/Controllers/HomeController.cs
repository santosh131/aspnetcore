using Microsoft.AspNetCore.Mvc;

namespace routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
