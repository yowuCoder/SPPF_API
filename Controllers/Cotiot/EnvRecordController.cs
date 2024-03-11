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
    public class EnvRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public EnvRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/EnvRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvRecord>>> GetEnvRecords()
        {
            return await _context.EnvRecords.ToListAsync();
        }

        // GET: api/EnvRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvRecord>> GetEnvRecord(long id)
        {
            var envRecord = await _context.EnvRecords.FindAsync(id);

            if (envRecord == null)
            {
                return NotFound();
            }

            return envRecord;
        }

        // PUT: api/EnvRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvRecord(long id, EnvRecord envRecord)
        {
            if (id != envRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(envRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvRecordExists(id))
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

        // POST: api/EnvRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvRecord>> PostEnvRecord(EnvRecord envRecord)
        {
            _context.EnvRecords.Add(envRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvRecord", new { id = envRecord.Id }, envRecord);
        }

        // DELETE: api/EnvRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvRecord(long id)
        {
            var envRecord = await _context.EnvRecords.FindAsync(id);
            if (envRecord == null)
            {
                return NotFound();
            }

            _context.EnvRecords.Remove(envRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvRecordExists(long id)
        {
            return _context.EnvRecords.Any(e => e.Id == id);
        }
    }
}
