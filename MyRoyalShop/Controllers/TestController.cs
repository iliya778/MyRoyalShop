using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyRoyalShop.Controllers
{
    public class TestController : Controller
    {
        
        public string test1()
        {
            return "test1";
        }

        [Authorize]
        public string test2()
        {
            return "test2";
        }
    }
}
