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
    public class MaterialTypesController : Controller
    {
        private readonly Okna24hContext _context;

        public MaterialTypesController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: MaterialTypes
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.MaterialsTypes.Include(m => m.Material).Include(m => m.Typ);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: MaterialTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialsTypes
                .Include(m => m.Material)
                .Include(m => m.Typ)
                .FirstOrDefaultAsync(m => m.MaterialTypeId == id);
            if (materialType == null)
            {
                return NotFound();
            }

            return View(materialType);
        }

        // GET: MaterialTypes/Create
        public IActionResult Create()
        {
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "Description");
            ViewData["TypeId"] = new SelectList(_context.Typs, "TypId", "Code");
            return View();
        }

        // POST: MaterialTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialTypeId,MaterialId,TypeId,Description,Code,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] MaterialType materialType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "Description", materialType.MaterialId);
            ViewData["TypeId"] = new SelectList(_context.Typs, "TypId", "Code", materialType.TypeId);
            return View(materialType);
        }

        // GET: MaterialTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialsTypes.FindAsync(id);
            if (materialType == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "Description", materialType.MaterialId);
            ViewData["TypeId"] = new SelectList(_context.Typs, "TypId", "Code", materialType.TypeId);
            return View(materialType);
        }

        // POST: MaterialTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialTypeId,MaterialId,TypeId,Description,Code,Price,PhotoUrl,IsActive,CreationDateTime,EditDateTime,DeleteDateTime")] MaterialType materialType)
        {
            if (id != materialType.MaterialTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialTypeExists(materialType.MaterialTypeId))
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
            ViewData["MaterialId"] = new SelectList(_context.Materials, "MaterialId", "Description", materialType.MaterialId);
            ViewData["TypeId"] = new SelectList(_context.Typs, "TypId", "Code", materialType.TypeId);
            return View(materialType);
        }

        // GET: MaterialTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialType = await _context.MaterialsTypes
                .Include(m => m.Material)
                .Include(m => m.Typ)
                .FirstOrDefaultAsync(m => m.MaterialTypeId == id);
            if (materialType == null)
            {
                return NotFound();
            }

            return View(materialType);
        }

        // POST: MaterialTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialType = await _context.MaterialsTypes.FindAsync(id);
            if (materialType != null)
            {
                _context.MaterialsTypes.Remove(materialType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialTypeExists(int id)
        {
            return _context.MaterialsTypes.Any(e => e.MaterialTypeId == id);
        }
    }
}
