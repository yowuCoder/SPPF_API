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
    public class ConnectionStatusController : ControllerBase
    {
        private readonly CotiotContext _context;

        public ConnectionStatusController(CotiotContext context)
        {
            _context = context;
        }

        // GET: api/ConnectionStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionStatus>>> GetConnectionStatuses()
        {
            return await _context.ConnectionStatuses.ToListAsync();
        }

        // GET: api/ConnectionStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConnectionStatus>> GetConnectionStatus(int id)
        {
            var connectionStatus = await _context.ConnectionStatuses.FindAsync(id);

            if (connectionStatus == null)
            {
                return NotFound();
            }

            return connectionStatus;
        }

        // PUT: api/ConnectionStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnectionStatus(int id, ConnectionStatus connectionStatus)
        {
            if (id != connectionStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(connectionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionStatusExists(id))
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

        // POST: api/ConnectionStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("script")]
        public async Task<ActionResult<ConnectionStatus>> PostConnectionStatusScript()
        {
            var connectionStatus = new List<ConnectionStatus>();
            var ipArray = new string[] { 
                "192.168.109.101", "192.168.109.102", "192.168.109.103",
                "192.168.109.111", "192.168.109.112", "192.168.109.113",
                "192.168.109.121", "192.168.109.122", "192.168.109.123",
                "192.168.109.131", "192.168.109.132", "192.168.109.133",
                "192.168.109.141", "192.168.109.142", "192.168.109.143",

            };
            foreach(var ip in ipArray)
            {
                connectionStatus.Add(new ConnectionStatus
                {
                    Name = "B½uUC1",
                    Status = false,    
                    Ip = ip,
                    UpdatedAt = DateTime.Now
                });
            }
            _context.ConnectionStatuses.AddRange(connectionStatus);
            await _context.SaveChangesAsync();

            return StatusCode(200);
        }
        [HttpPost]
        public async Task<ActionResult<ConnectionStatus>> PostConnectionStatus(ConnectionStatus connectionStatus)
        {
            _context.ConnectionStatuses.Add(connectionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnectionStatus", new { id = connectionStatus.Id }, connectionStatus);
        }

        // DELETE: api/ConnectionStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnectionStatus(int id)
        {
            var connectionStatus = await _context.ConnectionStatuses.FindAsync(id);
            if (connectionStatus == null)
            {
                return NotFound();
            }

            _context.ConnectionStatuses.Remove(connectionStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionStatusExists(int id)
        {
            return _context.ConnectionStatuses.Any(e => e.Id == id);
        }
    }
}
