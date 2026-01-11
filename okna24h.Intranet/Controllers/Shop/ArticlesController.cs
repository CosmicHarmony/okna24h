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
    public class ArticlesController : Controller
    {
        private readonly Okna24hContext _context;

        public ArticlesController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.Articles.Include(a => a.Glass).Include(a => a.MaterialTypeColor).Include(a => a.OpenningSystem).Include(a => a.Profile).Include(a => a.Roller).Include(a => a.Sash).Include(a => a.Shutter).Include(a => a.Size).Include(a => a.Sort);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Glass)
                .Include(a => a.MaterialTypeColor)
                .Include(a => a.OpenningSystem)
                .Include(a => a.Profile)
                .Include(a => a.Roller)
                .Include(a => a.Sash)
                .Include(a => a.Shutter)
                .Include(a => a.Size)
                .Include(a => a.Sort)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["GlassId"] = new SelectList(_context.Glasses, "GlassId", "Code");
            ViewData["MaterialTypeColorId"] = new SelectList(_context.MaterialTypeColors, "MaterialTypeColorId", "Code");
            ViewData["OpenningSystemId"] = new SelectList(_context.OpenningSystems, "OpenningSystemId", "Code");
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Code");
            ViewData["RollerId"] = new SelectList(_context.Rollers, "RollerId", "Code");
            ViewData["SashId"] = new SelectList(_context.Sashes, "SashId", "Code");
            ViewData["ShutterId"] = new SelectList(_context.Shutters, "ShutterId", "Code");
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Code");
            ViewData["SortId"] = new SelectList(_context.Sorts, "SortId", "Description");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleId,Code,Name,Price,FotoURL,Description,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,MaterialTypeColorId,GlassId,SortId,OpenningSystemId,ProfileId,RollerId,SashId,ShutterId,SizeId")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GlassId"] = new SelectList(_context.Glasses, "GlassId", "Code", article.GlassId);
            ViewData["MaterialTypeColorId"] = new SelectList(_context.MaterialTypeColors, "MaterialTypeColorId", "Code", article.MaterialTypeColorId);
            ViewData["OpenningSystemId"] = new SelectList(_context.OpenningSystems, "OpenningSystemId", "Code", article.OpenningSystemId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Code", article.ProfileId);
            ViewData["RollerId"] = new SelectList(_context.Rollers, "RollerId", "Code", article.RollerId);
            ViewData["SashId"] = new SelectList(_context.Sashes, "SashId", "Code", article.SashId);
            ViewData["ShutterId"] = new SelectList(_context.Shutters, "ShutterId", "Code", article.ShutterId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Code", article.SizeId);
            ViewData["SortId"] = new SelectList(_context.Sorts, "SortId", "Description", article.SortId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["GlassId"] = new SelectList(_context.Glasses, "GlassId", "Code", article.GlassId);
            ViewData["MaterialTypeColorId"] = new SelectList(_context.MaterialTypeColors, "MaterialTypeColorId", "Code", article.MaterialTypeColorId);
            ViewData["OpenningSystemId"] = new SelectList(_context.OpenningSystems, "OpenningSystemId", "Code", article.OpenningSystemId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Code", article.ProfileId);
            ViewData["RollerId"] = new SelectList(_context.Rollers, "RollerId", "Code", article.RollerId);
            ViewData["SashId"] = new SelectList(_context.Sashes, "SashId", "Code", article.SashId);
            ViewData["ShutterId"] = new SelectList(_context.Shutters, "ShutterId", "Code", article.ShutterId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Code", article.SizeId);
            ViewData["SortId"] = new SelectList(_context.Sorts, "SortId", "Description", article.SortId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,Code,Name,Price,FotoURL,Description,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,MaterialTypeColorId,GlassId,SortId,OpenningSystemId,ProfileId,RollerId,SashId,ShutterId,SizeId")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
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
            ViewData["GlassId"] = new SelectList(_context.Glasses, "GlassId", "Code", article.GlassId);
            ViewData["MaterialTypeColorId"] = new SelectList(_context.MaterialTypeColors, "MaterialTypeColorId", "Code", article.MaterialTypeColorId);
            ViewData["OpenningSystemId"] = new SelectList(_context.OpenningSystems, "OpenningSystemId", "Code", article.OpenningSystemId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "ProfileId", "Code", article.ProfileId);
            ViewData["RollerId"] = new SelectList(_context.Rollers, "RollerId", "Code", article.RollerId);
            ViewData["SashId"] = new SelectList(_context.Sashes, "SashId", "Code", article.SashId);
            ViewData["ShutterId"] = new SelectList(_context.Shutters, "ShutterId", "Code", article.ShutterId);
            ViewData["SizeId"] = new SelectList(_context.Sizes, "SizeId", "Code", article.SizeId);
            ViewData["SortId"] = new SelectList(_context.Sorts, "SortId", "Description", article.SortId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles
                .Include(a => a.Glass)
                .Include(a => a.MaterialTypeColor)
                .Include(a => a.OpenningSystem)
                .Include(a => a.Profile)
                .Include(a => a.Roller)
                .Include(a => a.Sash)
                .Include(a => a.Shutter)
                .Include(a => a.Size)
                .Include(a => a.Sort)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
