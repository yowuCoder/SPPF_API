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
    public class OperatorRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public OperatorRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/OperatorRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperatorRecord>>> GetOperatorRecords()
        {
            return await _context.OperatorRecords.ToListAsync();
        }

        // GET: api/OperatorRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperatorRecord>> GetOperatorRecord(int id)
        {
            var operatorRecord = await _context.OperatorRecords.FindAsync(id);

            if (operatorRecord == null)
            {
                return NotFound();
            }

            return operatorRecord;
        }

        // PUT: api/OperatorRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperatorRecord(int id, OperatorRecord operatorRecord)
        {
            if (id != operatorRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(operatorRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperatorRecordExists(id))
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

        // POST: api/OperatorRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperatorRecord>> PostOperatorRecord(OperatorRecord operatorRecord)
        {
            _context.OperatorRecords.Add(operatorRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperatorRecord", new { id = operatorRecord.Id }, operatorRecord);
        }

        // DELETE: api/OperatorRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperatorRecord(int id)
        {
            var operatorRecord = await _context.OperatorRecords.FindAsync(id);
            if (operatorRecord == null)
            {
                return NotFound();
            }

            _context.OperatorRecords.Remove(operatorRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperatorRecordExists(int id)
        {
            return _context.OperatorRecords.Any(e => e.Id == id);
        }
    }
}
