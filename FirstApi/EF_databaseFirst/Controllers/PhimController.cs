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
    public class PhimController : ControllerBase
    {
        private readonly ProjectContext _context;

        public PhimController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Phim
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Phim>>> GetPhims()
        {
          if (_context.Phims == null)
          {
              return NotFound();
          }
            return await _context.Phims.ToListAsync();
        }

        // GET: api/Phim/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Phim>> GetPhim(string id)
        {
          if (_context.Phims == null)
          {
              return NotFound();
          }
            var phim = await _context.Phims.FindAsync(id);

            if (phim == null)
            {
                return NotFound();
            }

            return phim;
        }

        // PUT: api/Phim/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutPhim(string id, Phim phim)
        {
            if (id != phim.MaPhim)
            {
                return BadRequest();
            }

            _context.Entry(phim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhimExists(id))
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

        // POST: api/Phim
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Phim>> PostPhim(Phim phim)
        {
          if (_context.Phims == null)
          {
              return Problem("Entity set 'ProjectContext.Phims'  is null.");
          }
            _context.Phims.Add(phim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhimExists(phim.MaPhim))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhim", new { id = phim.MaPhim }, phim);
        }

        // DELETE: api/Phim/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePhim(string id)
        {
            if (_context.Phims == null)
            {
                return NotFound();
            }
            var phim = await _context.Phims.FindAsync(id);
            if (phim == null)
            {
                return NotFound();
            }

            _context.Phims.Remove(phim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhimExists(string id)
        {
            return (_context.Phims?.Any(e => e.MaPhim == id)).GetValueOrDefault();
        }
    }
}
