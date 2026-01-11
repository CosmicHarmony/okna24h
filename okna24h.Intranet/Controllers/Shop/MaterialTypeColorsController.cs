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
    public class MaterialTypeColorsController : Controller
    {
        private readonly Okna24hContext _context;

        public MaterialTypeColorsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: MaterialTypeColors
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.MaterialTypeColors.Include(m => m.Colour).Include(m => m.MaterialType);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: MaterialTypeColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTypeColor = await _context.MaterialTypeColors
                .Include(m => m.Colour)
                .Include(m => m.MaterialType)
                .FirstOrDefaultAsync(m => m.MaterialTypeColorId == id);
            if (materialTypeColor == null)
            {
                return NotFound();
            }

            return View(materialTypeColor);
        }

        // GET: MaterialTypeColors/Create
        public IActionResult Create()
        {
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Code");
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialsTypes, "MaterialTypeId", "Code");
            return View();
        }

        // POST: MaterialTypeColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialTypeColorId,MaterialTypeId,ColourId,Description,Code,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] MaterialTypeColor materialTypeColor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialTypeColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Code", materialTypeColor.ColourId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialsTypes, "MaterialTypeId", "Code", materialTypeColor.MaterialTypeId);
            return View(materialTypeColor);
        }

        // GET: MaterialTypeColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTypeColor = await _context.MaterialTypeColors.FindAsync(id);
            if (materialTypeColor == null)
            {
                return NotFound();
            }
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Code", materialTypeColor.ColourId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialsTypes, "MaterialTypeId", "Code", materialTypeColor.MaterialTypeId);
            return View(materialTypeColor);
        }

        // POST: MaterialTypeColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialTypeColorId,MaterialTypeId,ColourId,Description,Code,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] MaterialTypeColor materialTypeColor)
        {
            if (id != materialTypeColor.MaterialTypeColorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialTypeColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialTypeColorExists(materialTypeColor.MaterialTypeColorId))
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
            ViewData["ColourId"] = new SelectList(_context.Colours, "ColourId", "Code", materialTypeColor.ColourId);
            ViewData["MaterialTypeId"] = new SelectList(_context.MaterialsTypes, "MaterialTypeId", "Code", materialTypeColor.MaterialTypeId);
            return View(materialTypeColor);
        }

        // GET: MaterialTypeColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTypeColor = await _context.MaterialTypeColors
                .Include(m => m.Colour)
                .Include(m => m.MaterialType)
                .FirstOrDefaultAsync(m => m.MaterialTypeColorId == id);
            if (materialTypeColor == null)
            {
                return NotFound();
            }

            return View(materialTypeColor);
        }

        // POST: MaterialTypeColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialTypeColor = await _context.MaterialTypeColors.FindAsync(id);
            if (materialTypeColor != null)
            {
                _context.MaterialTypeColors.Remove(materialTypeColor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialTypeColorExists(int id)
        {
            return _context.MaterialTypeColors.Any(e => e.MaterialTypeColorId == id);
        }
    }
}
