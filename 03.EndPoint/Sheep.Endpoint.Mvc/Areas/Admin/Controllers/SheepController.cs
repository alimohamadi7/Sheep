using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheep.Core.Application.Sheep.Queries;

namespace Sheep.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SheepController : Controller
    {
        private readonly IMediator _mediator;

        public SheepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: SheepController
        public async Task< ActionResult> Index( string trim ,int pageId)
        {
            var sheep=await _mediator.Send(new GetSheepQuery { trim=trim,PageId=pageId}    );
            return View(sheep.Result);
        }

        // GET: SheepController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SheepController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SheepController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SheepController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SheepController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SheepController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SheepController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
