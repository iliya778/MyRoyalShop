using Microsoft.AspNetCore.Mvc;
using MyRoyalShop.DataLayer.Context;

namespace MyRoyalShop.Controllers
{
    public class ProductController : Controller
    {
        MyRoyalShopDbContext _context;

        public ProductController(MyRoyalShopDbContext context)
        {
            _context = context;
        }

        [Route("/Group/{id}/{title}")]
        public IActionResult GetProductByGroupId(int id,string title,int pageId=1)
        {
            int take = 2;
            int skip = (pageId-1)*take;
            int PageCount = _context.Products.Count(p=> p.GroupId == id)/take;
            var result = _context.Products.Where(p => p.GroupId == id)
                .OrderByDescending(p => p.ProductId)
                .Skip(skip).Take(take);
            ViewBag.PageCount = PageCount;
            ViewBag.TitlePage = title;
            ViewBag.PageId= pageId;
            ViewBag.GroupId = id;
            return View(result);
        }

        [Route("Product/{id}")]
        public IActionResult ShowProduct(int id) 
        {
            return View(_context.Products.Find(id));
        }
    }
}
