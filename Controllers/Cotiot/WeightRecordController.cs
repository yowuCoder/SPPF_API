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
    public class WeightRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public WeightRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/WeightRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightRecord>>> GetWeightRecords()
        {
            return await _context.WeightRecords.ToListAsync();
        }

        // GET: api/WeightRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightRecord>> GetWeightRecord(long id)
        {
            var weightRecord = await _context.WeightRecords.FindAsync(id);

            if (weightRecord == null)
            {
                return NotFound();
            }

            return weightRecord;
        }

        // PUT: api/WeightRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightRecord(long id, WeightRecord weightRecord)
        {
            if (id != weightRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(weightRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeightRecordExists(id))
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

        // POST: api/WeightRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeightRecord>> PostWeightRecord(WeightRecord weightRecord)
        {
            _context.WeightRecords.Add(weightRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeightRecord", new { id = weightRecord.Id }, weightRecord);
        }

        // DELETE: api/WeightRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeightRecord(long id)
        {
            var weightRecord = await _context.WeightRecords.FindAsync(id);
            if (weightRecord == null)
            {
                return NotFound();
            }

            _context.WeightRecords.Remove(weightRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeightRecordExists(long id)
        {
            return _context.WeightRecords.Any(e => e.Id == id);
        }
    }
}
