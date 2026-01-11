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
    public class ShuttersController : Controller
    {
        private readonly Okna24hContext _context;

        public ShuttersController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Shutters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shutters.ToListAsync());
        }

        // GET: Shutters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shutter = await _context.Shutters
                .FirstOrDefaultAsync(m => m.ShutterId == id);
            if (shutter == null)
            {
                return NotFound();
            }

            return View(shutter);
        }

        // GET: Shutters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shutters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShutterId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Shutter shutter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shutter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shutter);
        }

        // GET: Shutters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shutter = await _context.Shutters.FindAsync(id);
            if (shutter == null)
            {
                return NotFound();
            }
            return View(shutter);
        }

        // POST: Shutters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShutterId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Shutter shutter)
        {
            if (id != shutter.ShutterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shutter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShutterExists(shutter.ShutterId))
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
            return View(shutter);
        }

        // GET: Shutters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shutter = await _context.Shutters
                .FirstOrDefaultAsync(m => m.ShutterId == id);
            if (shutter == null)
            {
                return NotFound();
            }

            return View(shutter);
        }

        // POST: Shutters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shutter = await _context.Shutters.FindAsync(id);
            if (shutter != null)
            {
                _context.Shutters.Remove(shutter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShutterExists(int id)
        {
            return _context.Shutters.Any(e => e.ShutterId == id);
        }
    }
}
