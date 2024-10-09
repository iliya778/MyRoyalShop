using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRoyalShop.Core.Securities;
using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.DataLayer.ViewModels;
using System.Security.Claims;

namespace MyRoyalShop.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        MyRoyalShopDbContext _dbcontext;
        public HomeController(MyRoyalShopDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if(ModelState.IsValid)
            {
                int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                string oldHashPassword = SecurePasswordHasher.EncodePasswordMd5(change.OldUserPassword);

                var user = _dbcontext.Users.SingleOrDefault(
                    u => u.UserId == userId && u.UserPassword == oldHashPassword);

                if (user == null)
                {
                    ModelState.AddModelError("OldUserPassword","رمز عبور فعلی صحیح نمی باشد ");
                    return View();
                }
                user.UserPassword = SecurePasswordHasher.EncodePasswordMd5(change.NewUserPassword);
                _dbcontext.Update(user);
                _dbcontext.SaveChanges();
                return Redirect("/Account/LogOut"); 
            }
            return View();
        }
    }
}
