using ASP6_SinAuth.Areas.Identity.Data;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View(/*await _context.User.Where(u=>u.laboratory!=null).Include(l => l.laboratory).ToListAsync()*/);
        }

        // GET: LabWorkers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabWorkers/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_context.User, "Id", "Email");
            ViewBag.Laboratory = new SelectList(_context.Laboratory, "Id", "Name");
            return View();
        }

        // POST: LabWorkers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Id, int laboratory)
        {
            User user = _context.User.Find(Id);
 
            if (user != null)
            {
                //user.laboratory = _context.Laboratory.Find(laboratory);
                //_context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                Console.WriteLine("Error creatring the worker ");
            }
            return View(user);
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
