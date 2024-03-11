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
    public class FatekRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public FatekRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/FatekRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FatekRecord>>> GetFatekRecords()
        {
            return await _context.FatekRecords.ToListAsync();
        }

        // GET: api/FatekRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FatekRecord>> GetFatekRecord(long id)
        {
            var fatekRecord = await _context.FatekRecords.FindAsync(id);

            if (fatekRecord == null)
            {
                return NotFound();
            }

            return fatekRecord;
        }

        // PUT: api/FatekRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFatekRecord(long id, FatekRecord fatekRecord)
        {
            if (id != fatekRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(fatekRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FatekRecordExists(id))
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

        // POST: api/FatekRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FatekRecord>> PostFatekRecord(FatekRecord fatekRecord)
        {
            _context.FatekRecords.Add(fatekRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFatekRecord", new { id = fatekRecord.Id }, fatekRecord);
        }

        // DELETE: api/FatekRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFatekRecord(long id)
        {
            var fatekRecord = await _context.FatekRecords.FindAsync(id);
            if (fatekRecord == null)
            {
                return NotFound();
            }

            _context.FatekRecords.Remove(fatekRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FatekRecordExists(long id)
        {
            return _context.FatekRecords.Any(e => e.Id == id);
        }
    }
}
