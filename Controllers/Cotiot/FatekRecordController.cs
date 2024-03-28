using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPPF_API.Helper;
using SPPF_API.Models.COTIOT;

namespace SPPF_API.Controllers_Cotiot
{
  
    public class WmvTempRecord
    {
        public string LowTemp { get; set; } = null!;
        public string HighTemp1 { get; set; } = null!;
        public string HighTemp2 { get; set; } = null!;
        public string HighTemp3 { get; set; } = null!;
    }
    [Route("[controller]")]
    [ApiController]
    public class FatekRecordController : ControllerBase
    {
        private readonly CotiotContext _context;
        private readonly RecordHelper<FatekRecord> _RecordHelper =new ();

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
        [HttpGet("line/{line}")]
     
      
        public async Task<ActionResult<WmvTempRecord>> GetScaleRecordsByLine(string line)
        {
            string converter(string val)
            {
                if (val == null)
                {
                    return "0";
                }
                return (Convert.ToInt32(val)/10).ToString();
            }
            try
            {
                var latestRecords = await _context.FatekRecords
            .Where(x => x.Line == line &&
                        x.CreatedAt == _context.FatekRecords
                            .Where(y => y.Line == line)
                            .Max(y => y.CreatedAt)).ToListAsync();
                
                var lowTempRecord = latestRecords.Where(x => x.Address == "42004").FirstOrDefault();
                var highTemp1Record = latestRecords.Where(x => x.Address == "42005").FirstOrDefault();
                var highTemp2Record = latestRecords.Where(x => x.Address == "42006").FirstOrDefault();
                var highTemp3Record = latestRecords.Where(x => x.Address == "42007").FirstOrDefault();
           
                WmvTempRecord wmvTempRecord = new WmvTempRecord
                {
                    LowTemp = converter(lowTempRecord?.Value)??"0",
                    HighTemp1 = converter( highTemp1Record?.Value) ?? "0",
                    HighTemp2 = converter (highTemp2Record?.Value) ?? "0",
                    HighTemp3 = converter(highTemp3Record?.Value) ?? "0"
                };
                return wmvTempRecord;
            }
            catch(Exception ex)
            {
                
                //return 500 status code and the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            

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
            if (fatekRecord == null )
            {
                return BadRequest("No FatekRecords provided.");
            }
            _context.FatekRecords.Add(fatekRecord);
            await _context.SaveChangesAsync();
            //  string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/fatek";
            /* string line = fatekRecord.Line;
             string docPath = @$"C:\\project\\data\\fatek\\{DateTime.Now.ToString("yyyyMMdd")}\\{line}\\";
             string json = JsonConvert.SerializeObject(fatekRecord);
             // Append text to an existing file named "WriteLines.txt".
             if (!Directory.Exists(docPath))
             {
                 Directory.CreateDirectory(docPath);
             }
             using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"fatek_{line}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt"), true))
             {
                 outputFile.WriteLine(json);
             }*/
            _RecordHelper.WriteRecordsToFile("fatek",fatekRecord.Line, fatekRecord);
            return CreatedAtAction("GetFatekRecord", new { id = fatekRecord.Id }, fatekRecord);
        }
      
        [HttpPost("list")]
        public async Task<ActionResult<IEnumerable<FatekRecord>>> PostFatekRecords(List<FatekRecord> fatekRecords)
        {
            if (fatekRecords == null || !fatekRecords.Any())
            {
                return BadRequest("No FatekRecords provided.");
            }
            foreach (var fatekRecord in fatekRecords)
            {
                _context.FatekRecords.Add(fatekRecord);
            }

            await _context.SaveChangesAsync();
            _RecordHelper.WriteRecordsToFile("fatek", fatekRecords[0].Line, fatekRecords);
          
            // Return the created records. This is optional and depends on your requirement.
            return CreatedAtAction("GetFatekRecordById", new { id = fatekRecords[0].Id }, fatekRecords);
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
