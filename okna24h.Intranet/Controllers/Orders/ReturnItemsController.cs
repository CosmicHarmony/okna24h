using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using okna24h.Data.Data;
using okna24h.Data.Data.Orders;

namespace okna24h.Intranet.Controllers.Orders
{
    public class ReturnItemsController : Controller
    {
        private readonly Okna24hContext _context;

        public ReturnItemsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: ReturnItems
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.ReturnItems.Include(r => r.OrderItem).Include(r => r.Return);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: ReturnItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnItem = await _context.ReturnItems
                .Include(r => r.OrderItem)
                .Include(r => r.Return)
                .FirstOrDefaultAsync(m => m.ReturnItemId == id);
            if (returnItem == null)
            {
                return NotFound();
            }

            return View(returnItem);
        }

        // GET: ReturnItems/Create
        public IActionResult Create()
        {
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId");
            ViewData["ReturnId"] = new SelectList(_context.Returns, "ReturnId", "Reason");
            return View();
        }

        // POST: ReturnItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnItemId,Quantity,Reason,IsApproved,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,UnitPrice,ReturnId,OrderItemId")] ReturnItem returnItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", returnItem.OrderItemId);
            ViewData["ReturnId"] = new SelectList(_context.Returns, "ReturnId", "Reason", returnItem.ReturnId);
            return View(returnItem);
        }

        // GET: ReturnItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnItem = await _context.ReturnItems.FindAsync(id);
            if (returnItem == null)
            {
                return NotFound();
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", returnItem.OrderItemId);
            ViewData["ReturnId"] = new SelectList(_context.Returns, "ReturnId", "Reason", returnItem.ReturnId);
            return View(returnItem);
        }

        // POST: ReturnItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnItemId,Quantity,Reason,IsApproved,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,UnitPrice,ReturnId,OrderItemId")] ReturnItem returnItem)
        {
            if (id != returnItem.ReturnItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnItemExists(returnItem.ReturnItemId))
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", returnItem.OrderItemId);
            ViewData["ReturnId"] = new SelectList(_context.Returns, "ReturnId", "Reason", returnItem.ReturnId);
            return View(returnItem);
        }

        // GET: ReturnItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnItem = await _context.ReturnItems
                .Include(r => r.OrderItem)
                .Include(r => r.Return)
                .FirstOrDefaultAsync(m => m.ReturnItemId == id);
            if (returnItem == null)
            {
                return NotFound();
            }

            return View(returnItem);
        }

        // POST: ReturnItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var returnItem = await _context.ReturnItems.FindAsync(id);
            if (returnItem != null)
            {
                _context.ReturnItems.Remove(returnItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnItemExists(int id)
        {
            return _context.ReturnItems.Any(e => e.ReturnItemId == id);
        }
    }
}
