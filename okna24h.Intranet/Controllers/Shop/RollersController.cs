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
    public class RollersController : Controller
    {
        private readonly Okna24hContext _context;

        public RollersController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Rollers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rollers.ToListAsync());
        }

        // GET: Rollers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roller = await _context.Rollers
                .FirstOrDefaultAsync(m => m.RollerId == id);
            if (roller == null)
            {
                return NotFound();
            }

            return View(roller);
        }

        // GET: Rollers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rollers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollerId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Roller roller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roller);
        }

        // GET: Rollers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roller = await _context.Rollers.FindAsync(id);
            if (roller == null)
            {
                return NotFound();
            }
            return View(roller);
        }

        // POST: Rollers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RollerId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Roller roller)
        {
            if (id != roller.RollerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollerExists(roller.RollerId))
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
            return View(roller);
        }

        // GET: Rollers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roller = await _context.Rollers
                .FirstOrDefaultAsync(m => m.RollerId == id);
            if (roller == null)
            {
                return NotFound();
            }

            return View(roller);
        }

        // POST: Rollers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roller = await _context.Rollers.FindAsync(id);
            if (roller != null)
            {
                _context.Rollers.Remove(roller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollerExists(int id)
        {
            return _context.Rollers.Any(e => e.RollerId == id);
        }
    }
}
