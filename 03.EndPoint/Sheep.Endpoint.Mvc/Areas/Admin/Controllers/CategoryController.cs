using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Endpoint.Mvc.WebframeWork.Validateattr;

namespace Sheep.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _categoryApplication.GetAllCategory(cancellationToken));
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public async Task<ActionResult> Create()
        {
            return PartialView(nameof(Create));
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Validate]
        public async Task<ActionResult> Create(CreateCommand createCommand,CancellationToken cancellationToken)
        {
            var result = await _categoryApplication.Create(createCommand, cancellationToken);
            return new JsonResult(result);
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
