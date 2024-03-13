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
    public class ViscosityRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public ViscosityRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/ViscosityRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViscosityRecord>>> GetViscosityRecords()
        {
            return await _context.ViscosityRecords.ToListAsync();
        }

        // GET: api/ViscosityRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViscosityRecord>> GetViscosityRecord(long id)
        {
            var viscosityRecord = await _context.ViscosityRecords.FindAsync(id);

            if (viscosityRecord == null)
            {
                return NotFound();
            }

            return viscosityRecord;
        }

        // PUT: api/ViscosityRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViscosityRecord(long id, ViscosityRecord viscosityRecord)
        {
            if (id != viscosityRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(viscosityRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViscosityRecordExists(id))
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

        // POST: api/ViscosityRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ViscosityRecord>> PostViscosityRecord(ViscosityRecord viscosityRecord)
        {
            _context.ViscosityRecords.Add(viscosityRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViscosityRecord", new { id = viscosityRecord.Id }, viscosityRecord);
        }

        // DELETE: api/ViscosityRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViscosityRecord(long id)
        {
            var viscosityRecord = await _context.ViscosityRecords.FindAsync(id);
            if (viscosityRecord == null)
            {
                return NotFound();
            }

            _context.ViscosityRecords.Remove(viscosityRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViscosityRecordExists(long id)
        {
            return _context.ViscosityRecords.Any(e => e.Id == id);
        }
    }
}
