using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Core.Application.SheepBirth.Contracts;

namespace Sheep.Endpoint.Mvc.Controllers
{
    public class SheepBrithController : Controller
    {
        private readonly ISheepBirthApplication _sheepApplication;

        public SheepBrithController(ISheepBirthApplication sheepApplication)
        {
            _sheepApplication = sheepApplication;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken, string trim = "", int pageId = 1)
        {
            return View(await _sheepApplication.GetAllSheep(cancellationToken, pageId, trim));
        }
    }
}
