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
    public class VocRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public VocRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/VocRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VocRecord>>> GetVocRecords()
        {
            return await _context.VocRecords.ToListAsync();
        }

        // GET: api/VocRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VocRecord>> GetVocRecord(long id)
        {
            var vocRecord = await _context.VocRecords.FindAsync(id);

            if (vocRecord == null)
            {
                return NotFound();
            }

            return vocRecord;
        }

        // PUT: api/VocRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVocRecord(long id, VocRecord vocRecord)
        {
            if (id != vocRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(vocRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocRecordExists(id))
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

        // POST: api/VocRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VocRecord>> PostVocRecord(VocRecord vocRecord)
        {
            _context.VocRecords.Add(vocRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVocRecord", new { id = vocRecord.Id }, vocRecord);
        }

        // DELETE: api/VocRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocRecord(long id)
        {
            var vocRecord = await _context.VocRecords.FindAsync(id);
            if (vocRecord == null)
            {
                return NotFound();
            }

            _context.VocRecords.Remove(vocRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VocRecordExists(long id)
        {
            return _context.VocRecords.Any(e => e.Id == id);
        }
    }
}
