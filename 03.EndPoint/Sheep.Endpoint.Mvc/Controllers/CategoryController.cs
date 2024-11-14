using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Category;
using Sheep.Core.Application.Category.Contracts;
using Sheep.Endpoint.Mvc.WebframeWork.Validateattr;
using System.Threading;

namespace Sheep.Endpoint.Mvc.Controllers
{

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
        public async Task<ActionResult> Edit(Guid Id,CancellationToken cancellationToken)
        {
            var result = await _categoryApplication.GetDetails(Id, cancellationToken);
            return PartialView(nameof(Edit),result);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Validate]
        public async Task<ActionResult> Edit(EditCommand editCommand, CancellationToken cancellationToken)
        {
            var result = await _categoryApplication.Edit(editCommand, cancellationToken);
            return new JsonResult(result);
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var result = await _categoryApplication.GetDetails(id, cancellationToken);
            return PartialView(nameof(Delete), result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfrim(Guid id, CancellationToken  cancellationToken)
        {
            var result = await _categoryApplication.Delete(id, cancellationToken);
            return new JsonResult(result);
        }
    }
}
