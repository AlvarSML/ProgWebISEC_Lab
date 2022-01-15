using ASP6_SinAuth.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP6_SinAuth.Controllers
{
    public class LabWorkers : Controller
    {

        private readonly ctxDatos _context;

        public LabWorkers(ctxDatos context)
        {
            _context = context;
        }

        // GET: LabWorkers
        public async Task<IActionResult> Index()
        {
            return View(_context.LaboratoryWorkers.Include(l => l.laboratory));
        }

        // GET: LabWorkers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabWorkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabWorkers/Create
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

        // GET: LabWorkers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LabWorkers/Edit/5
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

        // GET: LabWorkers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LabWorkers/Delete/5
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
