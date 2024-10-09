using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyRoyalShop.Core.Interfaces;
using MyRoyalShop.Core.Securities;
using MyRoyalShop.Core.Sender;
using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.DataLayer.ViewModels;
//using MyRoyalShop.Core.Interfaces;
//using MyRoyalShop.Core.Securities;
//using MyRoyalShop.DataLayer.ViewModels;
using System.Security.Claims;

namespace MyEshop.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        MyRoyalShopDbContext dbContext;
        public AccountController(IUserService userService, MyRoyalShopDbContext dbContext)
        {
            this.userService = userService;
            this.dbContext = dbContext;
        }


        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);


            if (userService.IsUserNameExist(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است");
                return View(register);
            }

            if (userService.IsEmailExist(register.UserEmail))
            {
                ModelState.AddModelError("UserEmail", "ایمیل تکراری است");
                return View(register);
            }

            userService.RegisterUser(register);

            #region Send email to user
            string activeCode = dbContext.Users.Single(u => u.UserEmail == register.UserEmail.Trim().ToLower())
                .ActiveCode;
            string emailBody = $"<p>{register.UserName} عزیز ، با تشکر از ثبت نام شما</p>" +
                "<p>جهت فعالسازی حساب کاربری خود روی لینک زیر کلیک کنید</p>" +
                $"<p><a href='https://localhost:7025/Account/ActiveUser?activeCode={activeCode}'>فعالسازی</a></p>";
            SendEmail.Send(register.UserEmail, "ایمیل فعالسازی", emailBody);

            #endregion


            return View("SuccessRegister", register);
        }
        #endregion

        #region ActiveAccount
        public IActionResult ActiveUser(string activeCode)
        {
            bool res = userService.ActiveUser(activeCode);

            return View(res);
        }
        #endregion

        
        #region Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            string hashPass = SecurePasswordHasher.EncodePasswordMd5(login.UserPassword);

            var user = dbContext.Users.SingleOrDefault
                (u => u.UserEmail == login.UserEmail.Trim().ToLower() &&
                u.UserPassword == hashPass);

            if (user == null)
            {
                ModelState.AddModelError("UserEmail", "اطلاعات صحیح نیست");
                return View(login);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError("UserEmail", "حساب کاربری فعال نشده است");
                return View(login);

            }

            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim("IsAdmin",user.IsAdmin.ToString()),
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }
        #endregion
        

        #region Sign Out
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
        #endregion
    }
}
