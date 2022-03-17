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
    public class LocalesController : ControllerBase
    {
        private readonly SharedDataContext _context;

        public LocalesController(SharedDataContext context)
        {
            _context = context;
        }

        // GET: api/Locales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locale>>> GetLocales()
        {
            return await _context.Locales.ToListAsync();
        }

        // GET: api/Locales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locale>> GetLocale(int id)
        {
            var locale = await _context.Locales.FindAsync(id);

            if (locale == null)
            {
                return NotFound();
            }

            return locale;
        }

        // PUT: api/Locales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocale(int id, Locale locale)
        {
            if (id != locale.Id)
            {
                return BadRequest();
            }

            _context.Entry(locale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocaleExists(id))
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

        // POST: api/Locales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locale>> PostLocale(Locale locale)
        {
            _context.Locales.Add(locale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocale", new { id = locale.Id }, locale);
        }

        // DELETE: api/Locales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocale(int id)
        {
            var locale = await _context.Locales.FindAsync(id);
            if (locale == null)
            {
                return NotFound();
            }

            _context.Locales.Remove(locale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocaleExists(int id)
        {
            return _context.Locales.Any(e => e.Id == id);
        }
    }
}
