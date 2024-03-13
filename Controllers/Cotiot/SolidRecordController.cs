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
    public class SolidRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public SolidRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/SolidRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolidRecord>>> GetSolidRecords()
        {
            return await _context.SolidRecords.ToListAsync();
        }

        // GET: api/SolidRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolidRecord>> GetSolidRecord(long id)
        {
            var solidRecord = await _context.SolidRecords.FindAsync(id);

            if (solidRecord == null)
            {
                return NotFound();
            }

            return solidRecord;
        }

        // PUT: api/SolidRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolidRecord(long id, SolidRecord solidRecord)
        {
            if (id != solidRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(solidRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolidRecordExists(id))
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

        // POST: api/SolidRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SolidRecord>> PostSolidRecord(SolidRecord solidRecord)
        {
            _context.SolidRecords.Add(solidRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolidRecord", new { id = solidRecord.Id }, solidRecord);
        }

        // DELETE: api/SolidRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolidRecord(long id)
        {
            var solidRecord = await _context.SolidRecords.FindAsync(id);
            if (solidRecord == null)
            {
                return NotFound();
            }

            _context.SolidRecords.Remove(solidRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolidRecordExists(long id)
        {
            return _context.SolidRecords.Any(e => e.Id == id);
        }
    }
}
