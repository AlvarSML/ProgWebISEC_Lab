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

        public class TestCreation
        {
            public int typeId { get; set; }
            public string labId { get; set; }
            public string userId { get; set; }
            public string comment { get; set; }
            public DateTime testDate { get; set; }
        }

        public class TestEdit : TestCreation
        {
            public int result { get; set; }
            public int testId { get; set; }
            public string technicianId { get; set; }
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
                string userid = (await _userManager.GetUserAsync(User)).Id;
                tests = await _context.Test.Where(t => t.client.Id.Equals(userid)).ToListAsync();
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

        // GET: Tests/Create/[lab]
        public IActionResult Create(int Id)
        {
            string labid = _context.TestType
                .Include(t => t.laboratory)
                .FirstOrDefault(t => t.Id == Id)
                .laboratory.IdLab;

            TestCreation tc = new TestCreation
            {
                userId = _userManager.GetUserId(User),
                labId = labid,
                typeId = Id,
                testDate = DateTime.Now
            };

            return View(tc);
        }

        // POST: Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestCreation testm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Test()
                {
                    creationDate = DateTime.Now,
                    testDate = testm.testDate,
                    type = _context.TestType.Find(testm.typeId),
                    laboratory = _context.Laboratory.Find(testm.labId),
                    description = testm.comment,
                    client = _context.User.Find(testm.userId)
                });

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("Error de modelo");
                //Console.WriteLine(testm.test.ToString());
            }

            return View();
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            TestEdit te = new TestEdit();

            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .Include(t=> t.laboratory)
                .Include(t=> t.client)
                .Include(t=> t.type)
                .FirstOrDefaultAsync(t=>t.Id == id);

            if (test == null)
            {
                return NotFound();
            } else
            {
                te.testDate = test.testDate;
                te.comment = test.description;
                te.labId = test.laboratory.IdLab;
                te.userId = test.client.Id;
                te.typeId = test.type.Id;
                te.testId = test.Id;
                te.technicianId = _userManager.GetUserId(User);

                return View(te);
            }

            
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("testId,comment,creationDate,testDate,result,technicianId")] TestEdit te)
        {

            if (ModelState.IsValid)
            {
                Test test = _context.Test.Find(te.testId);
                test.description = te.comment;
                test.technician = _context.LaboratoryWorker.Find(te.technicianId);
                test.result = te.result;

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
                return RedirectToAction(nameof(LabView));
            }
            return View(te);
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

            Laboratory lab = _context.LaboratoryWorker
                .Include(u => u.laboratory)
                .First(u => u.Id == userId)
                .laboratory;

            IEnumerable<Test> labTests = await _context.Test
                .Include(t => t.client)
                .Include(t => t.laboratory)
                .Where(t => t.laboratory.IdLab.Equals(lab.IdLab))
                .Include(t => t.type)
                .Include(t => t.technician)                
                .ToListAsync();

            ch.FutureTests = labTests
                .Where(t => t.result == null);

            ch.Results = labTests
                .Where(t => t.result != null);

            return View(ch);
        }
    }
}