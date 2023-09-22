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
    public class SuatChieuController : ControllerBase
    {
        private readonly ProjectContext _context;

        public SuatChieuController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/SuatChieu
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<SuatChieu>>> GetSuatChieus()
        {
          if (_context.SuatChieus == null)
          {
              return NotFound();
          }
            return await _context.SuatChieus.ToListAsync();
        }

        // GET: api/SuatChieu/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<SuatChieu>> GetSuatChieu(string id)
        {
          if (_context.SuatChieus == null)
          {
              return NotFound();
          }
            var suatChieu = await _context.SuatChieus.FindAsync(id);

            if (suatChieu == null)
            {
                return NotFound();
            }

            return suatChieu;
        }

        // PUT: api/SuatChieu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutSuatChieu(string id, SuatChieu suatChieu)
        {
            if (id != suatChieu.MaSc)
            {
                return BadRequest();
            }

            _context.Entry(suatChieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuatChieuExists(id))
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

        // POST: api/SuatChieu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<SuatChieu>> PostSuatChieu(SuatChieu suatChieu)
        {
          if (_context.SuatChieus == null)
          {
              return Problem("Entity set 'ProjectContext.SuatChieus'  is null.");
          }
            _context.SuatChieus.Add(suatChieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuatChieuExists(suatChieu.MaSc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuatChieu", new { id = suatChieu.MaSc }, suatChieu);
        }

        // DELETE: api/SuatChieu/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteSuatChieu(string id)
        {
            if (_context.SuatChieus == null)
            {
                return NotFound();
            }
            var suatChieu = await _context.SuatChieus.FindAsync(id);
            if (suatChieu == null)
            {
                return NotFound();
            }

            _context.SuatChieus.Remove(suatChieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuatChieuExists(string id)
        {
            return (_context.SuatChieus?.Any(e => e.MaSc == id)).GetValueOrDefault();
        }
    }
}
