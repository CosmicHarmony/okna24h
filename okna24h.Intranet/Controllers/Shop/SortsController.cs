using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.Shop;

namespace okna24h.Intranet.Controllers.Shop
{
    public class SortsController : Controller
    {
        private readonly Okna24hContext _context;

        public SortsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Sorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sorts.ToListAsync());
        }

        // GET: Sorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts
                .FirstOrDefaultAsync(m => m.SortId == id);
            if (sort == null)
            {
                return NotFound();
            }

            return View(sort);
        }

        // GET: Sorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SortId,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Sort sort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sort);
        }

        // GET: Sorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts.FindAsync(id);
            if (sort == null)
            {
                return NotFound();
            }
            return View(sort);
        }

        // POST: Sorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SortId,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Sort sort)
        {
            if (id != sort.SortId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SortExists(sort.SortId))
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
            return View(sort);
        }

        // GET: Sorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts
                .FirstOrDefaultAsync(m => m.SortId == id);
            if (sort == null)
            {
                return NotFound();
            }

            return View(sort);
        }

        // POST: Sorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sort = await _context.Sorts.FindAsync(id);
            if (sort != null)
            {
                _context.Sorts.Remove(sort);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SortExists(int id)
        {
            return _context.Sorts.Any(e => e.SortId == id);
        }
    }
}
