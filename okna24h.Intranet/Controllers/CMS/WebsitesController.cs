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
    public class WebsitesController : Controller
    {
        private readonly Okna24hContext _context;

        public WebsitesController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: Websites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Websites.ToListAsync());
        }

        // GET: Websites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Websites
                .FirstOrDefaultAsync(m => m.WebsiteID == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // GET: Websites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Websites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WebsiteID,TitleURL,Title,Description,Keywords,PhotoUrl,Content,Item,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,AccessLevel")] Website website)
        {
            if (ModelState.IsValid)
            {
                _context.Add(website);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(website);
        }

        // GET: Websites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Websites.FindAsync(id);
            if (website == null)
            {
                return NotFound();
            }
            return View(website);
        }

        // POST: Websites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WebsiteID,TitleURL,Title,Description,Keywords,PhotoUrl,Content,Item,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,AccessLevel")] Website website)
        {
            if (id != website.WebsiteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(website);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WebsiteExists(website.WebsiteID))
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
            return View(website);
        }

        // GET: Websites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var website = await _context.Websites
                .FirstOrDefaultAsync(m => m.WebsiteID == id);
            if (website == null)
            {
                return NotFound();
            }

            return View(website);
        }

        // POST: Websites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var website = await _context.Websites.FindAsync(id);
            if (website != null)
            {
                _context.Websites.Remove(website);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WebsiteExists(int id)
        {
            return _context.Websites.Any(e => e.WebsiteID == id);
        }
    }
}
