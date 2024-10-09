using Microsoft.AspNetCore.Mvc;

namespace MyRoyalShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // This is gay
        public IActionResult Index()
        {
            return View();
        }
        // another comment to see the changes

    }
}
