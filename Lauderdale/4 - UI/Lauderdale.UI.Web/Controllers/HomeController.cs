using Microsoft.AspNetCore.Mvc;

namespace Lauderdale.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
