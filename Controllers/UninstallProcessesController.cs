#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngineData;
using Models.Engine.Reference;

namespace dn6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UninstallProcessesController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public UninstallProcessesController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/UninstallProcesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UninstallProcess>>> GetUninstallProcesses()
        {
            return await _context.UninstallProcesses.ToListAsync();
        }

        // GET: api/UninstallProcesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UninstallProcess>> GetUninstallProcess(int id)
        {
            var uninstallProcess = await _context.UninstallProcesses.FindAsync(id);

            if (uninstallProcess == null)
            {
                return NotFound();
            }

            return uninstallProcess;
        }

        // PUT: api/UninstallProcesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUninstallProcess(int id, UninstallProcess uninstallProcess)
        {
            if (id != uninstallProcess.Id)
            {
                return BadRequest();
            }

            _context.Entry(uninstallProcess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UninstallProcessExists(id))
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

        // POST: api/UninstallProcesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UninstallProcess>> PostUninstallProcess(UninstallProcess uninstallProcess)
        {
            _context.UninstallProcesses.Add(uninstallProcess);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUninstallProcess", new { id = uninstallProcess.Id }, uninstallProcess);
        }

        // DELETE: api/UninstallProcesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUninstallProcess(int id)
        {
            var uninstallProcess = await _context.UninstallProcesses.FindAsync(id);
            if (uninstallProcess == null)
            {
                return NotFound();
            }

            _context.UninstallProcesses.Remove(uninstallProcess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UninstallProcessExists(int id)
        {
            return _context.UninstallProcesses.Any(e => e.Id == id);
        }
    }
}
