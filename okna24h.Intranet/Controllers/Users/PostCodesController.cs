using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.Users;

namespace okna24h.Intranet.Controllers.Users
{
    public class PostCodesController : Controller
    {
        private readonly Okna24hContext _context;

        public PostCodesController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: PostCodes
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.PostCodes.Include(p => p.City);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: PostCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCode = await _context.PostCodes
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PostCodeId == id);
            if (postCode == null)
            {
                return NotFound();
            }

            return View(postCode);
        }

        // GET: PostCodes/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name");
            return View();
        }

        // POST: PostCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostCodeId,Code,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,CityId")] PostCode postCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", postCode.CityId);
            return View(postCode);
        }

        // GET: PostCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCode = await _context.PostCodes.FindAsync(id);
            if (postCode == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", postCode.CityId);
            return View(postCode);
        }

        // POST: PostCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostCodeId,Code,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,CityId")] PostCode postCode)
        {
            if (id != postCode.PostCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCodeExists(postCode.PostCodeId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "Name", postCode.CityId);
            return View(postCode);
        }

        // GET: PostCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCode = await _context.PostCodes
                .Include(p => p.City)
                .FirstOrDefaultAsync(m => m.PostCodeId == id);
            if (postCode == null)
            {
                return NotFound();
            }

            return View(postCode);
        }

        // POST: PostCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postCode = await _context.PostCodes.FindAsync(id);
            if (postCode != null)
            {
                _context.PostCodes.Remove(postCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCodeExists(int id)
        {
            return _context.PostCodes.Any(e => e.PostCodeId == id);
        }
    }
}
