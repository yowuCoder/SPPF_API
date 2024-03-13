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
    public class AlarmSettingController : ControllerBase
    {
        private readonly CotiotContext _context;

        public AlarmSettingController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/AlarmSetting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlarmSetting>>> GetAlarmSettings()
        {
            return await _context.AlarmSettings.ToListAsync();
        }

        // GET: api/AlarmSetting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlarmSetting>> GetAlarmSetting(int id)
        {
            var alarmSetting = await _context.AlarmSettings.FindAsync(id);

            if (alarmSetting == null)
            {
                return NotFound();
            }

            return alarmSetting;
        }

        // PUT: api/AlarmSetting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlarmSetting(int id, AlarmSetting alarmSetting)
        {
            if (id != alarmSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(alarmSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlarmSettingExists(id))
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

        // POST: api/AlarmSetting
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlarmSetting>> PostAlarmSetting(AlarmSetting alarmSetting)
        {
            _context.AlarmSettings.Add(alarmSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlarmSetting", new { id = alarmSetting.Id }, alarmSetting);
        }

        // DELETE: api/AlarmSetting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlarmSetting(int id)
        {
            var alarmSetting = await _context.AlarmSettings.FindAsync(id);
            if (alarmSetting == null)
            {
                return NotFound();
            }

            _context.AlarmSettings.Remove(alarmSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlarmSettingExists(int id)
        {
            return _context.AlarmSettings.Any(e => e.Id == id);
        }
    }
}
