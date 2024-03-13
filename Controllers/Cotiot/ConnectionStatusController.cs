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
