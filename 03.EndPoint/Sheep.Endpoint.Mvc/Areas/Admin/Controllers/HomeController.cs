using Microsoft.AspNetCore.Mvc;

namespace Sheep.Endpoint.Mvc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
