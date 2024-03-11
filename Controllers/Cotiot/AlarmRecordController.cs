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
    public class AlarmRecordController : ControllerBase
    {
        private readonly CotiotContext _context;

        public AlarmRecordController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/AlarmRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlarmRecord>>> GetAlarmRecords()
        {
            return await _context.AlarmRecords.ToListAsync();
        }

        // GET: api/AlarmRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlarmRecord>> GetAlarmRecord(long id)
        {
            var alarmRecord = await _context.AlarmRecords.FindAsync(id);

            if (alarmRecord == null)
            {
                return NotFound();
            }

            return alarmRecord;
        }

        // PUT: api/AlarmRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlarmRecord(long id, AlarmRecord alarmRecord)
        {
            if (id != alarmRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(alarmRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlarmRecordExists(id))
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

        // POST: api/AlarmRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlarmRecord>> PostAlarmRecord(AlarmRecord alarmRecord)
        {
            _context.AlarmRecords.Add(alarmRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlarmRecord", new { id = alarmRecord.Id }, alarmRecord);
        }

        // DELETE: api/AlarmRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlarmRecord(long id)
        {
            var alarmRecord = await _context.AlarmRecords.FindAsync(id);
            if (alarmRecord == null)
            {
                return NotFound();
            }

            _context.AlarmRecords.Remove(alarmRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlarmRecordExists(long id)
        {
            return _context.AlarmRecords.Any(e => e.Id == id);
        }
    }
}
