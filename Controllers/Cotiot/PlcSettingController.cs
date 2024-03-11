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
    public class PlcSettingController : ControllerBase
    {
        private readonly CotiotContext _context;

        public PlcSettingController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/PlcSetting
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlcSetting>>> GetPlcSettings()
        {
            return await _context.PlcSettings.ToListAsync();
        }

        // GET: api/PlcSetting/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlcSetting>> GetPlcSetting(int id)
        {
            var plcSetting = await _context.PlcSettings.FindAsync(id);

            if (plcSetting == null)
            {
                return NotFound();
            }

            return plcSetting;
        }

        // PUT: api/PlcSetting/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlcSetting(int id, PlcSetting plcSetting)
        {
            if (id != plcSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(plcSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlcSettingExists(id))
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

        // POST: api/PlcSetting
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlcSetting>> PostPlcSetting(PlcSetting plcSetting)
        {
            _context.PlcSettings.Add(plcSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlcSetting", new { id = plcSetting.Id }, plcSetting);
        }

        // DELETE: api/PlcSetting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlcSetting(int id)
        {
            var plcSetting = await _context.PlcSettings.FindAsync(id);
            if (plcSetting == null)
            {
                return NotFound();
            }

            _context.PlcSettings.Remove(plcSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlcSettingExists(int id)
        {
            return _context.PlcSettings.Any(e => e.Id == id);
        }
    }
}
