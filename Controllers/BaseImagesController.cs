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
    public class BaseImagesController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public BaseImagesController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/BaseImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseImage>>> GetBaseImages()
        {
            return await _context.BaseImages.ToListAsync();
        }

        // GET: api/BaseImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseImage>> GetBaseImage(int id)
        {
            var baseImage = await _context.BaseImages.FindAsync(id);

            if (baseImage == null)
            {
                return NotFound();
            }

            return baseImage;
        }

        // PUT: api/BaseImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseImage(int id, BaseImage baseImage)
        {
            if (id != baseImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseImageExists(id))
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

        // POST: api/BaseImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseImage>> PostBaseImage(BaseImage baseImage)
        {
            _context.BaseImages.Add(baseImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseImage", new { id = baseImage.Id }, baseImage);
        }

        // DELETE: api/BaseImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseImage(int id)
        {
            var baseImage = await _context.BaseImages.FindAsync(id);
            if (baseImage == null)
            {
                return NotFound();
            }

            _context.BaseImages.Remove(baseImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseImageExists(int id)
        {
            return _context.BaseImages.Any(e => e.Id == id);
        }
    }
}
