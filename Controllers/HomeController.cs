using Microsoft.AspNetCore.Mvc;

namespace DHL_LOGIN_FINAL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
