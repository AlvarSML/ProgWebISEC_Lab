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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ASP6_SinAuth.Areas.Identity.Data;
using ASP6_SinAuth.Models.ViewModels;

namespace ASP6_SinAuth.Controllers
{
    public class TestsController : Controller
    {
        private readonly ctxDatos _context;
        private readonly UserManager<User> _userManager;
        public List<TestType> types;

        public TestsController(ctxDatos context, UserManager<User> usrMngr)
        {
            _context = context;
            _userManager = usrMngr;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            List<Test> tests;

            if (User.IsInRole("admin") || User.IsInRole("manager"))
            {
                tests = await _context.Test.ToListAsync();
            }
            else
            {
                tests = await _context.Test.Where(t => t.client.Email == User.Identity.Name).ToListAsync();
            }

            //ViewBag.types = _context.TestType.ToList();
            return View(tests);
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var test = await _context.Test
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            ViewData["type"] = new SelectList(_context.TestType, "Id", "type");
            ViewData["client"] = User.Identity.Name;

            return View(new TestCreation
            {
                laboratories = _context.Laboratory,
                userId = _userManager.GetUserId(User),
                test = new Test()
                {

                    testDate = DateTime.Now
                }
            });
        }

        // POST: Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestModification testm)
        {
            if (ModelState.IsValid)
            {
                // test.client = _context.Client.Find(_userManager.GetUserId(User));
                // test.type = _context.TestType.Find(type);
                // test.creationDate = DateTime.Now;

                _context.Add(new Test()
                {
                    creationDate = DateTime.Now,
                    testDate = testm.testDate,
                    type = _context.TestType.Find(int.Parse(testm.typeId)),
                    laboratory = _context.Laboratory.Find(int.Parse(testm.labId)),
                    description = testm.comment,
                    client = _context.User.Find(testm.userId)
                }); ;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("Error de modelo");
                //Console.WriteLine(testm.test.ToString());
            }

            ViewData["type"] = new SelectList(_context.TestType, "Id", "type", testm.typeId);
            return View();
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }



            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,description,creationDate,testDate,result")] Test test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.Id))
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
            return View(test);
        }

        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Test test = _context.Test
                .Include(t => t.laboratory)
                .FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _context.Test.FindAsync(id);
            _context.Test.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.Id == id);
        }

        public async Task<IActionResult> LabView()
        {
            ClientHome ch = new ClientHome();
            string userId = _userManager.GetUserId(User);
            Laboratory usr = _context.User
                .Include(u => u.laboratory)
                .First(u => u.Id == userId)
                .laboratory;

            IEnumerable<Test> labTests = await _context.Test
                .Include(t => t.client)
                .Include(t => t.laboratory)
                .Where(t => t.laboratory.Id == usr.Id)
                .Include(t => t.type)
                .Include(t => t.technician)                
                .ToListAsync();

            ch.FutureTests = labTests
                .Where(t => t.testDate.CompareTo(DateTime.Now) > 0);

            ch.Results = labTests
                .Where(t => t.testDate.CompareTo(DateTime.Now) < 0);

            return View(ch);
        }
    }
}