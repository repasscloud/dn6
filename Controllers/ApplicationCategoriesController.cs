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
    public class ApplicationCategoriesController : ControllerBase
    {
        private readonly EngineDataContext _context;

        public ApplicationCategoriesController(EngineDataContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationCategory>>> GetApplicationCategories()
        {
            return await _context.ApplicationCategories.ToListAsync();
        }

        // GET: api/ApplicationCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationCategory>> GetApplicationCategory(int id)
        {
            var applicationCategory = await _context.ApplicationCategories.FindAsync(id);

            if (applicationCategory == null)
            {
                return NotFound();
            }

            return applicationCategory;
        }

        // PUT: api/ApplicationCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationCategory(int id, ApplicationCategory applicationCategory)
        {
            if (id != applicationCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(applicationCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationCategoryExists(id))
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

        // POST: api/ApplicationCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationCategory>> PostApplicationCategory(ApplicationCategory applicationCategory)
        {
            _context.ApplicationCategories.Add(applicationCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationCategory", new { id = applicationCategory.Id }, applicationCategory);
        }

        // DELETE: api/ApplicationCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationCategory(int id)
        {
            var applicationCategory = await _context.ApplicationCategories.FindAsync(id);
            if (applicationCategory == null)
            {
                return NotFound();
            }

            _context.ApplicationCategories.Remove(applicationCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationCategoryExists(int id)
        {
            return _context.ApplicationCategories.Any(e => e.Id == id);
        }
    }
}
