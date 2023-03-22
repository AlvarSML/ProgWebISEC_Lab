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
    public class LaboratoryInputModel
    {
        public string? LabId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string LabOwner { get; set; }
    }

    public class LaboratoryTestTypes
    {
        public string LabId { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public IEnumerable<TestType> ExistingTypes { get; set; }
    }

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
                .FirstOrDefaultAsync(m => m.IdLab.Equals(id));
            if (laboratory == null)
            {
                return NotFound();
            }

            return View(laboratory);
        }

        // GET: Laboratories/Create
        public IActionResult Create()
        {
            return View(new LaboratoryInputModel()
            {
                LabOwner = getManager().Id
            });
        }

        // POST: Laboratories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location,Phone,LabOwner")] LaboratoryInputModel lab, string LabOwner)
        {
            lab.LabId = Guid.NewGuid().ToString();
            TryValidateModel(lab);

            if (ModelState.IsValid)
            {
                LaboratoryManager lm = _context.LaboratoryManager.Find(LabOwner);

                _context.Add(new Laboratory()
                {
                    IdLab = lab.LabId,
                    Name = lab.Name,
                    Location = lab.Location,
                    Phone = lab.Phone,
                    LabOwner = lm
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(lab);
            }
        }

        // GET: Laboratories/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratory = _context.Laboratory.Include(l => l.LabOwner).First(l => l.IdLab.Equals(id));

            if (laboratory == null)
            {
                return NotFound();
            }

            return View(new LaboratoryInputModel()
            {
                LabId = id,
                Name = laboratory.Name,
                Location = laboratory.Location,
                LabOwner = laboratory.LabOwner.Id,
                Phone = laboratory.Phone
            });
        }

        // POST: Laboratories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Location,Phone,LabOwner")] LaboratoryInputModel lab)
        {
            if (!id.Equals(lab.LabId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Laboratory laboratory = labFromImputModel(lab, getManager());
                try
                {
                    _context.Update(laboratory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratoryExists(laboratory.IdLab))
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
            return View(lab);
        }

        // GET: Laboratories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratory
                .FirstOrDefaultAsync(m => m.IdLab.Equals(id));
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

        // GET: TestTypes/5
        public async Task<IActionResult> TestTypes(string? id)
        {
            return View(new LaboratoryTestTypes()
            {
                LabId = id,
                ExistingTypes = await _context.TestType
                    .Include(t => t.laboratory)
                    .Where(t => t.laboratory.IdLab.Equals(id))
                    .ToListAsync()
            }); 
        }

        // POST: TestTypes/5
        [HttpPost, ActionName("TestTypes")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TestTypes([Bind("type,description,price,LabId")] LaboratoryTestTypes ltt)
        {
            if (ModelState.IsValid)
            {
                _context.TestType.Add(new TestType()
                {
                    type= ltt.type,
                    description =ltt.description,
                    price = ltt.price,
                    laboratory = _context.Laboratory.Find(ltt.LabId)

                });
                await _context.SaveChangesAsync();
            }

            return View(new LaboratoryTestTypes()
            {
                LabId = ltt.LabId,
                ExistingTypes = await _context.TestType
                    .Include(t => t.laboratory)
                    .Where(t => t.laboratory.IdLab.Equals(ltt.LabId))
                    .ToListAsync()
            });
        }


        private bool LaboratoryExists(string id)
        {
            return _context.Laboratory.Any(e => e.IdLab.Equals(id));
        }

        private IEnumerable<Laboratory> getLabsByOwner()
        {
            if (User.IsInRole("Admin") || true)
            {
                return _context.Laboratory.ToList();
            } else
            {
                return _context.Laboratory.Where(l => l.LabOwner == getManager());
            }
            
        }

        private LaboratoryManager getManager()
        {
            return _context.LaboratoryManager.Find(_userManager.GetUserId(User));
        }

        private Laboratory labFromImputModel(LaboratoryInputModel labm, User lm)
        {
            return new Laboratory()
            {
                IdLab = labm.LabId,
                Name = labm.Name,
                Location = labm.Location,
                Phone = labm.Phone,
                LabOwner = lm
            };
        }
    }
}
