﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Models;

namespace ASP6_SinAuth.Controllers
{
    public class TestTypesController : Controller
    {
        private readonly ctxDatos _context;

        public TestTypesController(ctxDatos context)
        {
            _context = context;
        }

        // GET: TestTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestType.ToListAsync());
        }

        // GET: TestTypes/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,type,description")] TestType testType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testType);
        }

        // GET: TestTypes/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,type,description")] TestType testType)
        {
            if (id != testType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
    }
}
