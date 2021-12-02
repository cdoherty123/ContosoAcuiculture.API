using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoAcuiculture.API.Models;

namespace ContosoAcuiculture.API
{ 
}
    /*
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContosoAcuiculturesController : ControllerBase
    {
        private readonly ContosoAcuicultureAPIContext _context;

        public ContosoAcuiculturesController(ContosoAcuicultureAPIContext context)
        {
            _context = context;
        }

        // GET: api/ContosoAcuicultures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContosoAcuiculture>>> GetContosoAcuiculture()
        {
            return await _context.ContosoAcuiculture.ToListAsync();
        }

        // GET: api/ContosoAcuicultures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContosoAcuiculture>> GetContosoAcuiculture(int id)
        {
            var contosoAcuiculture = await _context.ContosoAcuiculture.FindAsync(id);

            if (contosoAcuiculture == null)
            {
                return NotFound();
            }

            return contosoAcuiculture;
        }

        // PUT: api/ContosoAcuicultures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContosoAcuiculture(int id, ContosoAcuiculture contosoAcuiculture)
        {
            if (id != contosoAcuiculture.OfficeID)
            {
                return BadRequest();
            }

            _context.Entry(contosoAcuiculture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContosoAcuicultureExists(id))
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

        // POST: api/ContosoAcuicultures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContosoAcuiculture>> PostContosoAcuiculture(ContosoAcuiculture contosoAcuiculture)
        {
            _context.ContosoAcuiculture.Add(contosoAcuiculture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContosoAcuiculture", new { id = contosoAcuiculture.OfficeID }, contosoAcuiculture);
        }

        // DELETE: api/ContosoAcuicultures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContosoAcuiculture(int id)
        {
            var contosoAcuiculture = await _context.ContosoAcuiculture.FindAsync(id);
            if (contosoAcuiculture == null)
            {
                return NotFound();
            }

            _context.ContosoAcuiculture.Remove(contosoAcuiculture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContosoAcuicultureExists(int id)
        {
            return _context.ContosoAcuiculture.Any(e => e.OfficeID == id);
        }
    }
}
*/