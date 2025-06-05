using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Data;
using InventoryAPI.Models;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InventoryItem>> GetAll()
        {
            return Ok(_context.InventoryItems.ToList());
        }

        [HttpPost]
        public ActionResult<InventoryItem> Create(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.InventoryItems.Find(id);
            if (item == null) return NotFound();

            _context.InventoryItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
