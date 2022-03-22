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
    public class BaseImageEditionsController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public BaseImageEditionsController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/BaseImageEditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseImageEdition>>> GetBaseImageEditions()
        {
            return await _context.BaseImageEditions.ToListAsync();
        }

        // GET: api/BaseImageEditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseImageEdition>> GetBaseImageEdition(int id)
        {
            var baseImageEdition = await _context.BaseImageEditions.FindAsync(id);

            if (baseImageEdition == null)
            {
                return NotFound();
            }

            return baseImageEdition;
        }

        // PUT: api/BaseImageEditions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseImageEdition(int id, BaseImageEdition baseImageEdition)
        {
            if (id != baseImageEdition.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseImageEdition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseImageEditionExists(id))
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

        // POST: api/BaseImageEditions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseImageEdition>> PostBaseImageEdition(BaseImageEdition baseImageEdition)
        {
            _context.BaseImageEditions.Add(baseImageEdition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseImageEdition", new { id = baseImageEdition.Id }, baseImageEdition);
        }

        // DELETE: api/BaseImageEditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseImageEdition(int id)
        {
            var baseImageEdition = await _context.BaseImageEditions.FindAsync(id);
            if (baseImageEdition == null)
            {
                return NotFound();
            }

            _context.BaseImageEditions.Remove(baseImageEdition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseImageEditionExists(int id)
        {
            return _context.BaseImageEditions.Any(e => e.Id == id);
        }
    }
}
