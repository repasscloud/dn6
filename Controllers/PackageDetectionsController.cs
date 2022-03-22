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
    public class PackageDetectionsController : ControllerBase
    {
        private readonly SharedDataContext _context;

        public PackageDetectionsController(SharedDataContext context)
        {
            _context = context;
        }

        // GET: api/PackageDetections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageDetection>>> GetPackageDetections()
        {
            return await _context.PackageDetections.ToListAsync();
        }

        // GET: api/PackageDetections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDetection>> GetPackageDetection(int id)
        {
            var packageDetection = await _context.PackageDetections.FindAsync(id);

            if (packageDetection == null)
            {
                return NotFound();
            }

            return packageDetection;
        }

        // PUT: api/PackageDetections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageDetection(int id, PackageDetection packageDetection)
        {
            if (id != packageDetection.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageDetection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageDetectionExists(id))
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

        // POST: api/PackageDetections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageDetection>> PostPackageDetection(PackageDetection packageDetection)
        {
            _context.PackageDetections.Add(packageDetection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageDetection", new { id = packageDetection.Id }, packageDetection);
        }

        // DELETE: api/PackageDetections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageDetection(int id)
        {
            var packageDetection = await _context.PackageDetections.FindAsync(id);
            if (packageDetection == null)
            {
                return NotFound();
            }

            _context.PackageDetections.Remove(packageDetection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageDetectionExists(int id)
        {
            return _context.PackageDetections.Any(e => e.Id == id);
        }
    }
}
