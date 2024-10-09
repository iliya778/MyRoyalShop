using Microsoft.AspNetCore.Mvc;
using MyRoyalShop.DataLayer.Context;

namespace MyRoyalShop.Controllers
{
    public class SearchController : Controller
    {
        MyRoyalShopDbContext _context;
        public SearchController(MyRoyalShopDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string q)
        {
            var res = _context.Products
                .Where(p=>p.Title.Contains(q) || p.Tags.Contains(q)).ToList();
            return View(res);
        }
    }
}
