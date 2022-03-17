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
    public class TransferMethodsController : ControllerBase
    {
        private readonly SharedDataContext _context;

        public TransferMethodsController(SharedDataContext context)
        {
            _context = context;
        }

        // GET: api/TransferMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferMethod>>> GetTransferMethods()
        {
            return await _context.TransferMethods.ToListAsync();
        }

        // GET: api/TransferMethods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransferMethod>> GetTransferMethod(int id)
        {
            var transferMethod = await _context.TransferMethods.FindAsync(id);

            if (transferMethod == null)
            {
                return NotFound();
            }

            return transferMethod;
        }

        // PUT: api/TransferMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransferMethod(int id, TransferMethod transferMethod)
        {
            if (id != transferMethod.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferMethod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferMethodExists(id))
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

        // POST: api/TransferMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransferMethod>> PostTransferMethod(TransferMethod transferMethod)
        {
            _context.TransferMethods.Add(transferMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransferMethod", new { id = transferMethod.Id }, transferMethod);
        }

        // DELETE: api/TransferMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransferMethod(int id)
        {
            var transferMethod = await _context.TransferMethods.FindAsync(id);
            if (transferMethod == null)
            {
                return NotFound();
            }

            _context.TransferMethods.Remove(transferMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransferMethodExists(int id)
        {
            return _context.TransferMethods.Any(e => e.Id == id);
        }
    }
}
