using Microsoft.AspNetCore.Mvc;

namespace TecheSoft.Controllers.Auth
{
    public class UserLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
