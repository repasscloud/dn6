#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngineData;
using Models.Engine.Private;

namespace dn6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirusTotalScansController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public VirusTotalScansController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/VirusTotalScans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VirusTotalScan>>> GetVirusTotalScans()
        {
            return await _context.VirusTotalScans.ToListAsync();
        }

        // GET: api/VirusTotalScans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VirusTotalScan>> GetVirusTotalScan(int id)
        {
            var virusTotalScan = await _context.VirusTotalScans.FindAsync(id);

            if (virusTotalScan == null)
            {
                return NotFound();
            }

            return virusTotalScan;
        }

        // PUT: api/VirusTotalScans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirusTotalScan(int id, VirusTotalScan virusTotalScan)
        {
            if (id != virusTotalScan.Id)
            {
                return BadRequest();
            }

            _context.Entry(virusTotalScan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirusTotalScanExists(id))
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

        // POST: api/VirusTotalScans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VirusTotalScan>> PostVirusTotalScan(VirusTotalScan virusTotalScan)
        {
            _context.VirusTotalScans.Add(virusTotalScan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVirusTotalScan", new { id = virusTotalScan.Id }, virusTotalScan);
        }

        // DELETE: api/VirusTotalScans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVirusTotalScan(int id)
        {
            var virusTotalScan = await _context.VirusTotalScans.FindAsync(id);
            if (virusTotalScan == null)
            {
                return NotFound();
            }

            _context.VirusTotalScans.Remove(virusTotalScan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VirusTotalScanExists(int id)
        {
            return _context.VirusTotalScans.Any(e => e.Id == id);
        }
    }
}
