using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.Contracts;
using Sheep.Endpoint.Mvc.WebframeWork.Validateattr;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;
using Sheep.Core.Application.Background;


namespace Sheep.Endpoint.Mvc.Controllers
{
    public class SheepController : Controller
    {

        private readonly ISheepApplication _sheepApplication;
        private readonly IBackgroundJobs _backgroundJob;
        public SheepController(ISheepApplication sheepApplication, IBackgroundJobs backgroundJob)
        {
            _sheepApplication = sheepApplication;
            _backgroundJob = backgroundJob;
        }

        // GET: SheepController
        public async Task<IActionResult> Index(CancellationToken cancellationToken, string trim = "", int pageId = 1)
        {
 
                return View(await _sheepApplication.GetAllSheep(cancellationToken, pageId, trim));
            
        }

        // GET: SheepController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: SheepController/Create
        public async Task<IActionResult> Create(bool SheepBirth=false)
        {
            if (SheepBirth == true)
            return PartialView("BirthCreate");
            return PartialView(nameof(Create));
        }

        // POST: SheepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(CreateCommand command, CancellationToken cancellationToken)
        {
            var result=   await _sheepApplication.Create(command, cancellationToken);
            return new JsonResult(result);

        }

        // GET: SheepController/Edit/5
        public async Task<IActionResult> Edit(Guid id,CancellationToken cancellationToken)
        {
            return PartialView(nameof(Edit), await _sheepApplication.GetDetails(id,cancellationToken));
        }

        // POST: SheepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EditCommand command, CancellationToken cancellationToken)
        {
            var result = await _sheepApplication.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        // GET: SheepController/Delete/5
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var result = await _sheepApplication.GetDetails(id, cancellationToken);
            return PartialView(nameof(Delete), result);
        }

        // POST: SheepController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfrim(Guid id, CancellationToken cancellationToken)
        {
            var result = await _sheepApplication.Delete(id, cancellationToken);
            return new JsonResult(result);
        }
        [HttpGet]
        [Route("CalcuteAge")]
        public async Task<IActionResult>CalcuteAge(CancellationToken cancellationToken)
        {
            _backgroundJob.AddOrUpdate("Age",  () =>_sheepApplication.CalcuteAge(cancellationToken), RecuringType.Daily, "");

            return Ok();
        }
    }
}
