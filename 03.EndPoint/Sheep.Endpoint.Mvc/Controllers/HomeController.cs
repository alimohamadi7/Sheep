using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.SheepCategory;
using Sheep.Endpoint.Mvc.Models;
using System.Diagnostics;

namespace Sheep.Endpoint.Mvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISheepCategoryApplication _sheepCategoryApplication;
        public HomeController(ILogger<HomeController> logger, ISheepCategoryApplication sheepCategoryApplication)
        {
            _logger = logger;
            _sheepCategoryApplication = sheepCategoryApplication;
        }

        public async Task<IActionResult> Index()
        {
            SheepCountQuery sheepCountQuery = new SheepCountQuery()
            {
                CountEwe = _sheepCategoryApplication.GetEweCount(),
                CountRam=_sheepCategoryApplication.GetRamCount(),
                CountSixEighteenFemale=_sheepCategoryApplication.GetSixEighteenFemaleCount(),
                CountSixEighteenMale=_sheepCategoryApplication.GetSixEighteenMaleCount(),
                CountThreeSixFemale=_sheepCategoryApplication.GetThreeSixFemaleCount(),
                CountThreeSixMale=_sheepCategoryApplication.GetThreeSiXMaleCount(),
                CountZeroThreeFemale=_sheepCategoryApplication.GetZeroThreeFemaleCount(),
                CountZeroThreeMale=_sheepCategoryApplication.GetZeroThreeMaleCount(),
            };
            return View(sheepCountQuery);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
