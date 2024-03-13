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
    public class WmvRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public WmvRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/WmvRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WmvRecord>>> GetWmvRecords()
        {
            return await _context.WmvRecords.ToListAsync();
        }

        // GET: api/WmvRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WmvRecord>> GetWmvRecord(long id)
        {
            var wmvRecord = await _context.WmvRecords.FindAsync(id);

            if (wmvRecord == null)
            {
                return NotFound();
            }

            return wmvRecord;
        }

        // PUT: api/WmvRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWmvRecord(long id, WmvRecord wmvRecord)
        {
            if (id != wmvRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(wmvRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WmvRecordExists(id))
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

        // POST: api/WmvRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WmvRecord>> PostWmvRecord(WmvRecord wmvRecord)
        {
            _context.WmvRecords.Add(wmvRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWmvRecord", new { id = wmvRecord.Id }, wmvRecord);
        }

        // DELETE: api/WmvRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWmvRecord(long id)
        {
            var wmvRecord = await _context.WmvRecords.FindAsync(id);
            if (wmvRecord == null)
            {
                return NotFound();
            }

            _context.WmvRecords.Remove(wmvRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WmvRecordExists(long id)
        {
            return _context.WmvRecords.Any(e => e.Id == id);
        }
    }
}
