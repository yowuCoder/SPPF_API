using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPPF_API.Models.COTIOT;

namespace SPPF_API.Controllers_Cotiot
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrismaMigrationController : ControllerBase
    {
        private readonly CotiotContext _context;

        public PrismaMigrationController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/PrismaMigration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrismaMigration>>> GetPrismaMigrations()
        {
            return await _context.PrismaMigrations.ToListAsync();
        }

        // GET: api/PrismaMigration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrismaMigration>> GetPrismaMigration(string id)
        {
            var prismaMigration = await _context.PrismaMigrations.FindAsync(id);

            if (prismaMigration == null)
            {
                return NotFound();
            }

            return prismaMigration;
        }

        // PUT: api/PrismaMigration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrismaMigration(string id, PrismaMigration prismaMigration)
        {
            if (id != prismaMigration.Id)
            {
                return BadRequest();
            }

            _context.Entry(prismaMigration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrismaMigrationExists(id))
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

        // POST: api/PrismaMigration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrismaMigration>> PostPrismaMigration(PrismaMigration prismaMigration)
        {
            _context.PrismaMigrations.Add(prismaMigration);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrismaMigrationExists(prismaMigration.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrismaMigration", new { id = prismaMigration.Id }, prismaMigration);
        }

        // DELETE: api/PrismaMigration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrismaMigration(string id)
        {
            var prismaMigration = await _context.PrismaMigrations.FindAsync(id);
            if (prismaMigration == null)
            {
                return NotFound();
            }

            _context.PrismaMigrations.Remove(prismaMigration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrismaMigrationExists(string id)
        {
            return _context.PrismaMigrations.Any(e => e.Id == id);
        }
    }
}
