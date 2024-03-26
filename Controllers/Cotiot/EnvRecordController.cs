using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SPPF_API.Helper;
using SPPF_API.Models.COTIOT;

namespace SPPF_API.Controllers_Cotiot
{
    public class TemperatureData
    {
        public string DeviceId { get; set; } = null!;
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
   
    [Route("[controller]")]
    [ApiController]
    public class EnvRecordController : ControllerBase
    {
        private readonly CotiotContext _context;
        private readonly RecordHelper<EnvRecord> _RecordHelper = new();
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
        [HttpGet("GetLastTemperatureForEachDevice")]
       /* public async Task<ActionResult<IEnumerable<TemperatureData>>> GetLastTemperatureForEachDevice()
        {
            var temperatureRecords = await _context.EnvRecords
                .OrderByDescending(record => record.Time) // Order records by time descending
                .GroupBy(record => record.DeviceId) // Group by device id
                .Select(group => group.FirstOrDefault()) // Select first record from each group
                .Select(record => new TemperatureData
                {
                    DeviceId = record.DeviceId,
                    Temperature = record.Temperature,
                    Humidity = record.Humidity
                })
                .ToListAsync();

            return temperatureRecords;
        }*/
         public async Task<ActionResult<IEnumerable<TemperatureData>>> GetLastTemperatureForEachDevice()
         {
             var lastTemperatures = await _context.EnvRecords
                 .GroupBy(record => record.DeviceId)
                 .Select(group => new
                 {
                     DeviceId = group.Key,
                     MaxTime = group.Max(record => record.Time)
                 })
                 .ToListAsync();

             var temperatureRecords = new List<TemperatureData>();
             foreach (var lastTemperature in lastTemperatures)
             {
                 var temperatureRecord = await _context.EnvRecords
                     .Where(record => record.DeviceId == record.DeviceId && record.Time == lastTemperature.MaxTime)
                     .Select(record => new TemperatureData
                     {
                         DeviceId = record.DeviceId,
                         Temperature = record.Temperature,
                         Humidity = record.Humidity
                     })
                     .FirstOrDefaultAsync();

                 temperatureRecords.Add(temperatureRecord);
             }

             return temperatureRecords;
         }
        [HttpGet("getTemperatureData")]
        public async Task<ActionResult<IEnumerable<TemperatureData>>> GetTemperatureData(string date)
        {
            var conn = _context.Database.GetDbConnection();
            
                await conn.OpenAsync();

                var query = @"
                SELECT 
                    device_id AS DeviceId,
                    ROUND(AVG(CAST(temperature AS FLOAT)), 0) AS Temperature,
                    ROUND(AVG(CAST(humidity AS FLOAT)), 0) AS Humidity
                FROM 
                    env_record
                WHERE 
                    CONVERT(DATE, [time]) = @Date
                GROUP BY 
                    device_id;";

                return (await conn.QueryAsync<TemperatureData>(query, new { Date = date })).ToList();

              
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
            try
            {
              
                _context.EnvRecords.Add(envRecord);
                await _context.SaveChangesAsync();
                _RecordHelper.WriteRecordsToFile("env", "env", envRecord);
                return CreatedAtAction("GetEnvRecord", new { id = envRecord.Id }, envRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
        [HttpPost("list")]
        public async Task<ActionResult<EnvRecord>> PostEnvRecordList(List<EnvRecord> envRecords)
        {
            if (envRecords == null || envRecords.Count == 0)
            {
                return BadRequest("No EnvRecords provided.");
            }
            _context.EnvRecords.AddRange(envRecords);
            await _context.SaveChangesAsync();
            _RecordHelper.WriteRecordsToFile("env", "env", envRecords);
            return CreatedAtAction("GetEnvRecord", new { id = envRecords[0].Id }, envRecords);
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
