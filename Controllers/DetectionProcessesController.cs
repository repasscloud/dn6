#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Shared;
using SharedData;

namespace dn6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectionProcessesController : ControllerBase
    {
        private readonly SharedDataContext _context;

        public DetectionProcessesController(SharedDataContext context)
        {
            _context = context;
        }

        // GET: api/DetectionProcesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetectionProcess>>> GetDetectionProcesses()
        {
            return await _context.DetectionProcesses.ToListAsync();
        }

        // GET: api/DetectionProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetectionProcess>> GetDetectionProcess(int id)
        {
            var detectionProcess = await _context.DetectionProcesses.FindAsync(id);

            if (detectionProcess == null)
            {
                return NotFound();
            }

            return detectionProcess;
        }

        // PUT: api/DetectionProcesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetectionProcess(int id, DetectionProcess detectionProcess)
        {
            if (id != detectionProcess.Id)
            {
                return BadRequest();
            }

            _context.Entry(detectionProcess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetectionProcessExists(id))
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

        // POST: api/DetectionProcesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetectionProcess>> PostDetectionProcess(DetectionProcess detectionProcess)
        {
            _context.DetectionProcesses.Add(detectionProcess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetectionProcess", new { id = detectionProcess.Id }, detectionProcess);
        }

        // DELETE: api/DetectionProcesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetectionProcess(int id)
        {
            var detectionProcess = await _context.DetectionProcesses.FindAsync(id);
            if (detectionProcess == null)
            {
                return NotFound();
            }

            _context.DetectionProcesses.Remove(detectionProcess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetectionProcessExists(int id)
        {
            return _context.DetectionProcesses.Any(e => e.Id == id);
        }
    }
}
