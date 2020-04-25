using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using einkaufsliste_api.Models;

namespace einkaufsliste_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseItemsController : ControllerBase
    {
        private readonly PurchaseContext _context;

        public PurchaseItemsController(PurchaseContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseItem>>> GetPurchaseItems()
        {
            return await _context.PurchaseItems.ToListAsync();
        }

        // GET: api/PurchaseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseItem>> GetPurchaseItem(long id)
        {
            var purchaseItem = await _context.PurchaseItems.FindAsync(id);

            if (purchaseItem == null)
            {
                return NotFound();
            }

            return purchaseItem;
        }

        // PUT: api/PurchaseItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseItem(long id, PurchaseItem purchaseItem)
        {
            if (id != purchaseItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchaseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PurchaseItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseItem>> PostPurchaseItem(PurchaseItem purchaseItem)
        {
            _context.PurchaseItems.Add(purchaseItem);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetPurchaseItem", new { id = purchaseItem.Id }, purchaseItem);
            return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchaseItem.Id }, purchaseItem);
        }

        // DELETE: api/PurchaseItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseItem>> DeletePurchaseItem(long id)
        {
            var purchaseItem = await _context.PurchaseItems.FindAsync(id);
            if (purchaseItem == null)
            {
                return NotFound();
            }

            _context.PurchaseItems.Remove(purchaseItem);
            await _context.SaveChangesAsync();

            return purchaseItem;
        }

        private bool PurchaseItemExists(long id)
        {
            return _context.PurchaseItems.Any(e => e.Id == id);
        }
    }
}
