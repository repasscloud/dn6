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
    public class ExecutablesController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public ExecutablesController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/Executables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Executable>>> GetExecutables()
        {
            return await _context.Executables.ToListAsync();
        }

        // GET: api/Executables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Executable>> GetExecutable(int id)
        {
            var executable = await _context.Executables.FindAsync(id);

            if (executable == null)
            {
                return NotFound();
            }

            return executable;
        }

        // PUT: api/Executables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExecutable(int id, Executable executable)
        {
            if (id != executable.Id)
            {
                return BadRequest();
            }

            _context.Entry(executable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExecutableExists(id))
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

        // POST: api/Executables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Executable>> PostExecutable(Executable executable)
        {
            _context.Executables.Add(executable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExecutable", new { id = executable.Id }, executable);
        }

        // DELETE: api/Executables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExecutable(int id)
        {
            var executable = await _context.Executables.FindAsync(id);
            if (executable == null)
            {
                return NotFound();
            }

            _context.Executables.Remove(executable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExecutableExists(int id)
        {
            return _context.Executables.Any(e => e.Id == id);
        }
    }
}
