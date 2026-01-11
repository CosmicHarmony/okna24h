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
    public class InvoiceItemsController : Controller
    {
        private readonly Okna24hContext _context;

        public InvoiceItemsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: InvoiceItems
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.InvoiceItems.Include(i => i.Invoice).Include(i => i.OrderItem).Include(i => i.Tax);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: InvoiceItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems
                .Include(i => i.Invoice)
                .Include(i => i.OrderItem)
                .Include(i => i.Tax)
                .FirstOrDefaultAsync(m => m.InvoiceItemId == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // GET: InvoiceItems/Create
        public IActionResult Create()
        {
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceCode");
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId");
            ViewData["TaxId"] = new SelectList(_context.Taxes, "TaxId", "Description");
            return View();
        }

        // POST: InvoiceItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceItemId,BasePricePerUnit,Quantity,Discount,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,OrderItemId,InvoiceId,TaxId")] InvoiceItem invoiceItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceCode", invoiceItem.InvoiceId);
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", invoiceItem.OrderItemId);
            ViewData["TaxId"] = new SelectList(_context.Taxes, "TaxId", "Description", invoiceItem.TaxId);
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceCode", invoiceItem.InvoiceId);
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", invoiceItem.OrderItemId);
            ViewData["TaxId"] = new SelectList(_context.Taxes, "TaxId", "Description", invoiceItem.TaxId);
            return View(invoiceItem);
        }

        // POST: InvoiceItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceItemId,BasePricePerUnit,Quantity,Discount,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,OrderItemId,InvoiceId,TaxId")] InvoiceItem invoiceItem)
        {
            if (id != invoiceItem.InvoiceItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceItemExists(invoiceItem.InvoiceItemId))
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
            ViewData["InvoiceId"] = new SelectList(_context.Invoices, "InvoiceId", "InvoiceCode", invoiceItem.InvoiceId);
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", invoiceItem.OrderItemId);
            ViewData["TaxId"] = new SelectList(_context.Taxes, "TaxId", "Description", invoiceItem.TaxId);
            return View(invoiceItem);
        }

        // GET: InvoiceItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceItem = await _context.InvoiceItems
                .Include(i => i.Invoice)
                .Include(i => i.OrderItem)
                .Include(i => i.Tax)
                .FirstOrDefaultAsync(m => m.InvoiceItemId == id);
            if (invoiceItem == null)
            {
                return NotFound();
            }

            return View(invoiceItem);
        }

        // POST: InvoiceItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem != null)
            {
                _context.InvoiceItems.Remove(invoiceItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceItemExists(int id)
        {
            return _context.InvoiceItems.Any(e => e.InvoiceItemId == id);
        }
    }
}
