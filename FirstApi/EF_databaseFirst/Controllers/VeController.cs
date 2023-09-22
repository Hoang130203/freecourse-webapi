using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF_databaseFirst.Models;

namespace EF_databaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeController : ControllerBase
    {
        private readonly ProjectContext _context;

        public VeController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Ve
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Ve>>> GetVes()
        {
          if (_context.Ves == null)
          {
              return NotFound();
          }
            return await _context.Ves.ToListAsync();
        }

        // GET: api/Ve/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Ve>> GetVe(string id)
        {
          if (_context.Ves == null)
          {
              return NotFound();
          }
            var ve = await _context.Ves.FindAsync(id);

            if (ve == null)
            {
                return NotFound();
            }

            return ve;
        }

        // PUT: api/Ve/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutVe(string id, Ve ve)
        {
            if (id != ve.MaVe)
            {
                return BadRequest();
            }

            _context.Entry(ve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeExists(id))
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

        // POST: api/Ve
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Ve>> PostVe(Ve ve)
        {
          if (_context.Ves == null)
          {
              return Problem("Entity set 'ProjectContext.Ves'  is null.");
          }
            _context.Ves.Add(ve);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VeExists(ve.MaVe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVe", new { id = ve.MaVe }, ve);
        }

        // DELETE: api/Ve/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteVe(string id)
        {
            if (_context.Ves == null)
            {
                return NotFound();
            }
            var ve = await _context.Ves.FindAsync(id);
            if (ve == null)
            {
                return NotFound();
            }

            _context.Ves.Remove(ve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeExists(string id)
        {
            return (_context.Ves?.Any(e => e.MaVe == id)).GetValueOrDefault();
        }
    }
}
