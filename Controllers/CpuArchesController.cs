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
    public class CpuArchesController : ControllerBase
    {
        private readonly SharedDataContext _context;

        public CpuArchesController(SharedDataContext context)
        {
            _context = context;
        }

        // GET: api/CpuArches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CpuArch>>> GetCpuArches()
        {
            return await _context.CpuArches.ToListAsync();
        }

        // GET: api/CpuArches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CpuArch>> GetCpuArch(int id)
        {
            var cpuArch = await _context.CpuArches.FindAsync(id);

            if (cpuArch == null)
            {
                return NotFound();
            }

            return cpuArch;
        }

        // PUT: api/CpuArches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpuArch(int id, CpuArch cpuArch)
        {
            if (id != cpuArch.Id)
            {
                return BadRequest();
            }

            _context.Entry(cpuArch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpuArchExists(id))
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

        // POST: api/CpuArches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CpuArch>> PostCpuArch(CpuArch cpuArch)
        {
            _context.CpuArches.Add(cpuArch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpuArch", new { id = cpuArch.Id }, cpuArch);
        }

        // DELETE: api/CpuArches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCpuArch(int id)
        {
            var cpuArch = await _context.CpuArches.FindAsync(id);
            if (cpuArch == null)
            {
                return NotFound();
            }

            _context.CpuArches.Remove(cpuArch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CpuArchExists(int id)
        {
            return _context.CpuArches.Any(e => e.Id == id);
        }
    }
}
