using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.CMS;

namespace okna24h.Intranet.Controllers.CMS
{
    public class CmsTextsController : Controller
    {
        private readonly Okna24hContext _context;

        public CmsTextsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: CmsTexts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CmsTexts.ToListAsync());
        }

        // GET: CmsTexts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmsText = await _context.CmsTexts
                .FirstOrDefaultAsync(m => m.TextId == id);
            if (cmsText == null)
            {
                return NotFound();
            }

            return View(cmsText);
        }

        // GET: CmsTexts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CmsTexts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TextId,Key,Language,Value,Category,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,AccessLevel")] CmsText cmsText)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmsText);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmsText);
        }

        // GET: CmsTexts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmsText = await _context.CmsTexts.FindAsync(id);
            if (cmsText == null)
            {
                return NotFound();
            }
            return View(cmsText);
        }

        // POST: CmsTexts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TextId,Key,Language,Value,Category,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,AccessLevel")] CmsText cmsText)
        {
            if (id != cmsText.TextId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmsText);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmsTextExists(cmsText.TextId))
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
            return View(cmsText);
        }

        // GET: CmsTexts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmsText = await _context.CmsTexts
                .FirstOrDefaultAsync(m => m.TextId == id);
            if (cmsText == null)
            {
                return NotFound();
            }

            return View(cmsText);
        }

        // POST: CmsTexts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmsText = await _context.CmsTexts.FindAsync(id);
            if (cmsText != null)
            {
                _context.CmsTexts.Remove(cmsText);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CmsTextExists(int id)
        {
            return _context.CmsTexts.Any(e => e.TextId == id);
        }
    }
}
