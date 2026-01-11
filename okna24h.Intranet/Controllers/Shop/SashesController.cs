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
    public class SashesController : Controller
    {
        private readonly Okna24hContext _context;

        public SashesController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Sashes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sashes.ToListAsync());
        }

        // GET: Sashes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sash = await _context.Sashes
                .FirstOrDefaultAsync(m => m.SashId == id);
            if (sash == null)
            {
                return NotFound();
            }

            return View(sash);
        }

        // GET: Sashes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sashes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SashId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Sash sash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sash);
        }

        // GET: Sashes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sash = await _context.Sashes.FindAsync(id);
            if (sash == null)
            {
                return NotFound();
            }
            return View(sash);
        }

        // POST: Sashes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SashId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Sash sash)
        {
            if (id != sash.SashId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SashExists(sash.SashId))
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
            return View(sash);
        }

        // GET: Sashes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sash = await _context.Sashes
                .FirstOrDefaultAsync(m => m.SashId == id);
            if (sash == null)
            {
                return NotFound();
            }

            return View(sash);
        }

        // POST: Sashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sash = await _context.Sashes.FindAsync(id);
            if (sash != null)
            {
                _context.Sashes.Remove(sash);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SashExists(int id)
        {
            return _context.Sashes.Any(e => e.SashId == id);
        }
    }
}
