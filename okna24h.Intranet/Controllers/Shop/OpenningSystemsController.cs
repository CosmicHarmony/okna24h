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
    public class OpenningSystemsController : Controller
    {
        private readonly Okna24hContext _context;

        public OpenningSystemsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: OpenningSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpenningSystems.ToListAsync());
        }

        // GET: OpenningSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openningSystem = await _context.OpenningSystems
                .FirstOrDefaultAsync(m => m.OpenningSystemId == id);
            if (openningSystem == null)
            {
                return NotFound();
            }

            return View(openningSystem);
        }

        // GET: OpenningSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpenningSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpenningSystemId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] OpenningSystem openningSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(openningSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openningSystem);
        }

        // GET: OpenningSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openningSystem = await _context.OpenningSystems.FindAsync(id);
            if (openningSystem == null)
            {
                return NotFound();
            }
            return View(openningSystem);
        }

        // POST: OpenningSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpenningSystemId,Code,Name,Description,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] OpenningSystem openningSystem)
        {
            if (id != openningSystem.OpenningSystemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(openningSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpenningSystemExists(openningSystem.OpenningSystemId))
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
            return View(openningSystem);
        }

        // GET: OpenningSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openningSystem = await _context.OpenningSystems
                .FirstOrDefaultAsync(m => m.OpenningSystemId == id);
            if (openningSystem == null)
            {
                return NotFound();
            }

            return View(openningSystem);
        }

        // POST: OpenningSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var openningSystem = await _context.OpenningSystems.FindAsync(id);
            if (openningSystem != null)
            {
                _context.OpenningSystems.Remove(openningSystem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpenningSystemExists(int id)
        {
            return _context.OpenningSystems.Any(e => e.OpenningSystemId == id);
        }
    }
}
