using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.DataLayer.ViewModels;

namespace MyRoyalShop.Components
{
    public class ProductGroupViewComponent:ViewComponent
    {
        MyRoyalShopDbContext _context;
        public ProductGroupViewComponent(MyRoyalShopDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var res = _context.ProductGroups
                .Include(p=> p.product)
                .Select(p=> new ShowGroupViewModel()
                {
                    GroupId = p.GroupId,
                    GroupTitle = p.GroupTitle,
                    ProductCount = p.product.Count,
                }).ToList();
                
            return View("/Views/Components/ShowGroup.cshtml",res);
        }
    }
}
