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
    [Route("[controller]")]
    [ApiController]
    public class SpeedRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public SpeedRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/SpeedRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeedRecord>>> GetSpeedRecords()
        {
            return await _context.SpeedRecords.ToListAsync();
        }

        // GET: api/SpeedRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeedRecord>> GetSpeedRecord(long id)
        {
            var speedRecord = await _context.SpeedRecords.FindAsync(id);

            if (speedRecord == null)
            {
                return NotFound();
            }

            return speedRecord;
        }

        // PUT: api/SpeedRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeedRecord(long id, SpeedRecord speedRecord)
        {
            if (id != speedRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(speedRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeedRecordExists(id))
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

        // POST: api/SpeedRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpeedRecord>> PostSpeedRecord(SpeedRecord speedRecord)
        {
            _context.SpeedRecords.Add(speedRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeedRecord", new { id = speedRecord.Id }, speedRecord);
        }

        // DELETE: api/SpeedRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeedRecord(long id)
        {
            var speedRecord = await _context.SpeedRecords.FindAsync(id);
            if (speedRecord == null)
            {
                return NotFound();
            }

            _context.SpeedRecords.Remove(speedRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpeedRecordExists(long id)
        {
            return _context.SpeedRecords.Any(e => e.Id == id);
        }
    }
}
