using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemMe.Data;
using InventoryManagementSystemMe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace InventoryManagementSystemMe.Controllers
{
    [Route("[controller]")]
    public class PurchaseController : Controller
    {
        private readonly InventoryManagementContext _context;

        public PurchaseController(InventoryManagementContext context)
        {
            _context = context;
        }

        // GET: Purchase
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var purchase = await _context.Purchase.ToListAsync();
            return View(purchase); // Returns the list view of purchases
        }

        // GET: Purchase/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var purchase = await _context.Products.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase); // Returns the details view of a specific purchases
        }

        // GET: Purchases/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new purchase
        }

        // POST: Purchase/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the purchase list
            }
            return View(purchase);
        }

        // GET: Purchase/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            return View(purchase); // Returns the edit view for a specific purchase
        }

        // POST: Purchase/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Purchase purchase)
        {
            if (id != purchase.PurchaseID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the purchase list
            }
            return View(purchase);
        }

        // GET: Purchase/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase); // Returns the delete confirmation view
        }

        // POST: Purchase/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase != null)
            {
                _context.Purchase.Remove(purchase);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the purchase list
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.PurchaseID == id);
        }
    }
}
