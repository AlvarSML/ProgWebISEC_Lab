#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Models;
using Microsoft.AspNetCore.Identity;
using ASP6_SinAuth.Areas.Identity.Data;

namespace ASP6_SinAuth.Controllers
{
    public class LaboratoriesController : Controller
    {
        private readonly ctxDatos _context;
        private readonly UserManager<User> _userManager;

        public LaboratoriesController(ctxDatos context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Laboratories
        public async Task<IActionResult> Index()
        {
       
            return View(getLabsByOwner());
        }

        // GET: Laboratories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratory == null)
            {
                return NotFound();
            }

            return View(laboratory);
        }

        // GET: Laboratories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laboratories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Phone")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                laboratory.LabOwner = _context.LaboratoryManager.Find(User);
                _context.Add(laboratory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratory);
        }

        // GET: Laboratories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratory.FindAsync(id);
            if (laboratory == null)
            {
                return NotFound();
            }
            return View(laboratory);
        }

        // POST: Laboratories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Phone")] Laboratory laboratory)
        {
            if (id != laboratory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratoryExists(laboratory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(laboratory);
        }

        // GET: Laboratories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratory == null)
            {
                return NotFound();
            }

            return View(laboratory);
        }

        // POST: Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratory = await _context.Laboratory.FindAsync(id);
            _context.Laboratory.Remove(laboratory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratoryExists(int id)
        {
            return _context.Laboratory.Any(e => e.Id == id);
        }

        private IEnumerable<Laboratory> getLabsByOwner()
        {
            string uid = _userManager.GetUserId(User);
            LaboratoryManager lm = _context.LaboratoryManager.Find(uid);
            return _context.Laboratory.Where(l => l.LabOwner == lm);

        }
    }
}
