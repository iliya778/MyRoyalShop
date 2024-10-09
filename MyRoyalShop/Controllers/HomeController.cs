using Microsoft.AspNetCore.Mvc;
using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.Models;
using System.Diagnostics;

namespace MyRoyalShop.Controllers
{
    public class HomeController : Controller
    {
        MyRoyalShopDbContext _context;
        public HomeController(MyRoyalShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.OrderByDescending(p=> p.productGroup));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}