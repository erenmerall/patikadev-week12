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
    [Route("api/competitors")]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }

        // GET /api/competitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Competitors>>> GetAll()
        {
            return await _context.Competitors.Include(c => c.Category).ToListAsync();
        }

        // GET /api/competitors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Competitors>> GetById(int id)
        {
            var competitor = await _context.Competitors.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if (competitor == null) return NotFound();
            return competitor;
        }

        // GET /api/competitors/categories/{CategoryId}
        [HttpGet("categories/{CategoryId}")]
        public async Task<ActionResult<IEnumerable<Competitors>>> GetByCategory(int CategoryId)
        {
            var competitors = await _context.Competitors.Where(c => c.CategoryId == CategoryId).ToListAsync();
            return competitors;
        }

        // POST /api/competitors
        [HttpPost]
        public async Task<ActionResult<Competitors>> Create(Competitors competitor)
        {
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
        }

        // PUT /api/competitors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Competitors competitor)
        {
            if (id != competitor.Id) return BadRequest();
            _context.Entry(competitor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/competitors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var competitor = await _context.Competitors.FindAsync(id);
            if (competitor == null) return NotFound();
            _context.Competitors.Remove(competitor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}