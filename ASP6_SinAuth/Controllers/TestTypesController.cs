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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Identity;
using ASP6_SinAuth.Areas.Identity.Data;

namespace ASP6_SinAuth.Controllers
{
    public class TestTypesController : Controller
    {
        private readonly ctxDatos _context;
        private readonly UserManager<User> _userManager;

        public TestTypesController(ctxDatos context, UserManager<User> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string type { get; set; }
            public string description { get; set; }
            public float price { get; set; }
        }



        // GET: TestTypes
        //[Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Index()
        {
            string uid = _userManager.GetUserId(User);
            LaboratoryManager lm = _context.LaboratoryManager.Find(uid);
            IEnumerable<Laboratory> labs = _context.Laboratory.Where(l => l.LabOwner == lm);

            return View(await _context.TestType.Include(t=>t.laboratory).Where(t=>labs.Contains(t.laboratory)).ToListAsync());
        }

        // GET: TestTypes/Public/[filter]
        public async Task<IActionResult> Public(string? filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                return View(await _context.TestType
                    .Include(t => t.laboratory)
                    .Where(t=>(t.type.Contains(filter) || t.description.Contains(filter) || t.laboratory.Name.Contains(filter) || t.laboratory.Location.Contains(filter)))
                    .ToListAsync());
            }

            return View(await _context.TestType
                .Include(t => t.laboratory)
                .ToListAsync());
        }

        // GET: TestTypes/Details/5
        [Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testType == null)
            {
                return NotFound();
            }

            return View(testType);
        }

        // GET: TestTypes/Create
        [Authorize(Roles = "LaboratoryManager")]
        public IActionResult Create()
        {
            ViewData["labs"] = new SelectList(getLabsByOwner(), "Id", "Name");
            return View();
        }

        // POST: TestTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Create([Bind("Id,type,description")] TestType testType, String price, int laboratoryId)
        {
            Decimal p;
            if (ModelState.IsValid)
            {
                Decimal.TryParse(price.Replace('.', ','), out p);
                testType.price = p;
                _context.Add(testType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testType);
        }

        // GET: TestTypes/Edit/5
        [Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType.FindAsync(id);
            if (testType == null)
            {
                return NotFound();
            }
            return View(testType);
        }

        // POST: TestTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,type,description,price")] TestType testType,string price)
        {
            Decimal p;
            if (id != testType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Decimal.TryParse(price.Replace('.', ','), out p);
                    testType.price = p;
                    _context.Update(testType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestTypeExists(testType.Id))
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
            return View(testType);
        }

        // GET: TestTypes/Delete/5
        [Authorize(Roles = "LaboratoryManager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testType = await _context.TestType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testType == null)
            {
                return NotFound();
            }

            return View(testType);
        }

        // POST: TestTypes/Delete/5
        [Authorize(Roles = "LaboratoryManager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testType = await _context.TestType.FindAsync(id);
            _context.TestType.Remove(testType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestTypeExists(int id)
        {
            return _context.TestType.Any(e => e.Id == id);
        }

        private IEnumerable<Laboratory> getLabsByOwner()
        {
            string uid = _userManager.GetUserId(User);
            LaboratoryManager lm = _context.LaboratoryManager.Find(uid);
            return _context.Laboratory.Where(l => l.LabOwner == lm);

        }
    }
}
