using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Data;
using Survivor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoryController(SurvivorDbContext context)
        {
            _context = context;
        }

        // GET /api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return await _context.Category.Include(c => c.Competitors).ToListAsync();
        }

        // GET /api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _context.Category.Include(c => c.Competitors).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            return category;
        }

        // POST /api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // PUT /api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null) return NotFound();
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}