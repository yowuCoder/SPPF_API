using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPPF_API.Helper;
using SPPF_API.Models.COTIOT;

namespace SPPF_API.Controllers_Cotiot
{
    public class ScaleValues
    {
      public string CurrentWeight { get; set; }=null!;
        public string SettingWeight { get; set; } = null!;
    }
    [Route("[controller]")]
    [ApiController]
    public class ScaleRecordController : ControllerBase
    {
        private readonly CotiotContext _context;
        private readonly RecordHelper<ScaleRecord> _RecordHelper = new();
        private readonly ILogger<ScaleRecordController> _logger;
        public ScaleRecordController(CotiotContext context, ILogger<ScaleRecordController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private string ConvertHexToDecimal(string hex1, string hex2)
        {

            // string hex1 = "05DC";
            //string hex2 = "0000";
            _logger.LogInformation($"hex1: {hex1}, hex2: {hex2}");
            int num1 = int.Parse(hex1, System.Globalization.NumberStyles.HexNumber);
            int num2 = int.Parse(hex2, System.Globalization.NumberStyles.HexNumber);


            // int sum = num1 + num2;
            string decimalValue = (Convert.ToInt32(hex2+hex1, 16)/10).ToString();

            _logger.LogInformation($"decimalValueeeeeeeeeeeeeeeeeeeeee: {decimalValue}");



            return decimalValue;
        }
     
        // GET: api/ScaleRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScaleRecord>>> GetScaleRecords()
        {
            return await _context.ScaleRecords.ToListAsync();
        }
        [HttpGet("line/{line}")]
        public async Task<ActionResult<ScaleValues>>GetScaleRecordsByLine(string line)
        {
            try
            {
                var latestRecords = await _context.ScaleRecords
             .Where(x => x.Line == line &&
                         x.CreatedAt == _context.ScaleRecords
                             .Where(y => y.Line == line)
                             .Max(y => y.CreatedAt)).ToListAsync();

                var nowValues = latestRecords.Where(x => x.Address == "D1800" || x.Address == "D1801").OrderBy(x=>x.Address).ToList();
                var settingValues = latestRecords.Where(x => x.Address == "D2022" || x.Address == "D2023").OrderBy(x => x.Address).ToList();
               
                /* var scaleValues = new ScaleValues
                 {
                     NowValues = nowValues.ToList(),
                     SettingValues = settingValues.ToList()
                 };*/
               var currentWeight = ConvertHexToDecimal(nowValues[0].Value, nowValues[1].Value);
                var settingWeight =ConvertHexToDecimal(settingValues[0].Value, settingValues[1].Value);
                return new ScaleValues { CurrentWeight = currentWeight ?? "0", SettingWeight=settingWeight ?? "0" };
            }
            catch (Exception ex)
            {
            
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // GET: api/ScaleRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScaleRecord>> GetScaleRecord(long id)
        {
            var scaleRecord = await _context.ScaleRecords.FindAsync(id);

            if (scaleRecord == null)
            {
                return NotFound();
            }

            return scaleRecord;
        }

        // PUT: api/ScaleRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScaleRecord(long id, ScaleRecord scaleRecord)
        {
            if (id != scaleRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(scaleRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScaleRecordExists(id))
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

        // POST: api/ScaleRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScaleRecord>> PostScaleRecord(ScaleRecord scaleRecord)
        {
            _context.ScaleRecords.Add(scaleRecord);
            await _context.SaveChangesAsync();
            _RecordHelper.WriteRecordsToFile("scale", scaleRecord.Line, scaleRecord);
            return CreatedAtAction("GetScaleRecord", new { id = scaleRecord.Id }, scaleRecord);
        }
        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<ScaleRecord>>> PostFatekRecords(List<ScaleRecord> scaleRecords)
        {
            if (scaleRecords == null || !scaleRecords.Any())
            {
                return BadRequest("No scaleRecords provided.");
            }
            foreach (var scaleRecord in scaleRecords)
            {
                _context.ScaleRecords.Add(scaleRecord);
            }

            await _context.SaveChangesAsync();
            _RecordHelper.WriteRecordsToFile("scale", scaleRecords[0].Line, scaleRecords);

            // Return the created records. This is optional and depends on your requirement.
            return CreatedAtAction("GetFatekRecordById", new { id = scaleRecords[0].Id }, scaleRecords);
        }
        // DELETE: api/ScaleRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScaleRecord(long id)
        {
            var scaleRecord = await _context.ScaleRecords.FindAsync(id);
            if (scaleRecord == null)
            {
                return NotFound();
            }

            _context.ScaleRecords.Remove(scaleRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScaleRecordExists(long id)
        {
            return _context.ScaleRecords.Any(e => e.Id == id);
        }
    }
}
