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
    public class PhongChieuController : ControllerBase
    {
        private readonly ProjectContext _context;

        public PhongChieuController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/PhongChieu
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PhongChieu>>> GetPhongChieus()
        {
          if (_context.PhongChieus == null)
          {
              return NotFound();
          }
            return await _context.PhongChieus.ToListAsync();
        }

        // GET: api/PhongChieu/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<PhongChieu>> GetPhongChieu(string id)
        {
          if (_context.PhongChieus == null)
          {
              return NotFound();
          }
            var phongChieu = await _context.PhongChieus.FindAsync(id);

            if (phongChieu == null)
            {
                return NotFound();
            }

            return phongChieu;
        }

        // PUT: api/PhongChieu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutPhongChieu(string id, PhongChieu phongChieu)
        {
            if (id != phongChieu.MaPhong)
            {
                return BadRequest();
            }

            _context.Entry(phongChieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongChieuExists(id))
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

        // POST: api/PhongChieu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<PhongChieu>> PostPhongChieu(PhongChieu phongChieu)
        {
          if (_context.PhongChieus == null)
          {
              return Problem("Entity set 'ProjectContext.PhongChieus'  is null.");
          }
            _context.PhongChieus.Add(phongChieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhongChieuExists(phongChieu.MaPhong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhongChieu", new { id = phongChieu.MaPhong }, phongChieu);
        }

        // DELETE: api/PhongChieu/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePhongChieu(string id)
        {
            if (_context.PhongChieus == null)
            {
                return NotFound();
            }
            var phongChieu = await _context.PhongChieus.FindAsync(id);
            if (phongChieu == null)
            {
                return NotFound();
            }

            _context.PhongChieus.Remove(phongChieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhongChieuExists(string id)
        {
            return (_context.PhongChieus?.Any(e => e.MaPhong == id)).GetValueOrDefault();
        }
    }
}
