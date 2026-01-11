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
    public class TypsController : Controller
    {
        private readonly Okna24hContext _context;

        public TypsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Typs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typs.ToListAsync());
        }

        // GET: Typs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typs
                .FirstOrDefaultAsync(m => m.TypId == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        // GET: Typs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Typ typ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typ);
        }

        // GET: Typs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typs.FindAsync(id);
            if (typ == null)
            {
                return NotFound();
            }
            return View(typ);
        }

        // POST: Typs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] Typ typ)
        {
            if (id != typ.TypId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypExists(typ.TypId))
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
            return View(typ);
        }

        // GET: Typs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typs
                .FirstOrDefaultAsync(m => m.TypId == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        // POST: Typs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typ = await _context.Typs.FindAsync(id);
            if (typ != null)
            {
                _context.Typs.Remove(typ);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypExists(int id)
        {
            return _context.Typs.Any(e => e.TypId == id);
        }
    }
}
