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
    public class ShipmentItemsController : Controller
    {
        private readonly Okna24hContext _context;

        public ShipmentItemsController(Okna24hContext context)
        {
            _context = context;
        }

        // GET: ShipmentItems
        public async Task<IActionResult> Index()
        {
            var okna24hContext = _context.ShipmentItems.Include(s => s.OrderItem).Include(s => s.Shipment);
            return View(await okna24hContext.ToListAsync());
        }

        // GET: ShipmentItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentItem = await _context.ShipmentItems
                .Include(s => s.OrderItem)
                .Include(s => s.Shipment)
                .FirstOrDefaultAsync(m => m.ShipmentItemId == id);
            if (shipmentItem == null)
            {
                return NotFound();
            }

            return View(shipmentItem);
        }

        // GET: ShipmentItems/Create
        public IActionResult Create()
        {
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId");
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "Carrier");
            return View();
        }

        // POST: ShipmentItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipmentItemId,Quantity,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,ShipmentId,OrderItemId")] ShipmentItem shipmentItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipmentItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", shipmentItem.OrderItemId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "Carrier", shipmentItem.ShipmentId);
            return View(shipmentItem);
        }

        // GET: ShipmentItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentItem = await _context.ShipmentItems.FindAsync(id);
            if (shipmentItem == null)
            {
                return NotFound();
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", shipmentItem.OrderItemId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "Carrier", shipmentItem.ShipmentId);
            return View(shipmentItem);
        }

        // POST: ShipmentItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipmentItemId,Quantity,IsActive,CreationDateTime,EditDateTime,DeleteDateTime,ShipmentId,OrderItemId")] ShipmentItem shipmentItem)
        {
            if (id != shipmentItem.ShipmentItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipmentItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentItemExists(shipmentItem.ShipmentItemId))
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", shipmentItem.OrderItemId);
            ViewData["ShipmentId"] = new SelectList(_context.Shipments, "ShipmentId", "Carrier", shipmentItem.ShipmentId);
            return View(shipmentItem);
        }

        // GET: ShipmentItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentItem = await _context.ShipmentItems
                .Include(s => s.OrderItem)
                .Include(s => s.Shipment)
                .FirstOrDefaultAsync(m => m.ShipmentItemId == id);
            if (shipmentItem == null)
            {
                return NotFound();
            }

            return View(shipmentItem);
        }

        // POST: ShipmentItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipmentItem = await _context.ShipmentItems.FindAsync(id);
            if (shipmentItem != null)
            {
                _context.ShipmentItems.Remove(shipmentItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentItemExists(int id)
        {
            return _context.ShipmentItems.Any(e => e.ShipmentItemId == id);
        }
    }
}
