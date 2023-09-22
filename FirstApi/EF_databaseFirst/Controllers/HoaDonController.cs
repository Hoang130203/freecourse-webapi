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
    public class HoaDonController : ControllerBase
    {
        private readonly ProjectContext _context;

        public HoaDonController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/HoaDon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetHoaDons()
        {
          if (_context.HoaDons == null)
          {
              return NotFound();
          }
            return await _context.HoaDons.ToListAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<HoaDon>> GetHoaDon(string id)
        {
          if (_context.HoaDons == null)
          {
              return NotFound();
          }
            var hoaDon = await _context.HoaDons.FindAsync(id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return hoaDon;
        }

        // PUT: api/HoaDon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutHoaDon(string id)
        {
            //cập nhật chuyển hình thức thanh toán thành offline
            var hoaDon= _context.HoaDons.FirstOrDefault(h=>h.MaHoaDon==id);
            hoaDon.HinhThucThanhToan = "offline";
            if (id != hoaDon.MaHoaDon)
            {
                return BadRequest();
            }

            _context.Entry(hoaDon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(id))
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

        // POST: api/HoaDon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<HoaDon>> PostHoaDon(HoaDon hoaDon)
        {
          if (_context.HoaDons == null)
          {
              return Problem("Entity set 'ProjectContext.HoaDons'  is null.");
          }
            _context.HoaDons.Add(hoaDon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HoaDonExists(hoaDon.MaHoaDon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoaDon", new { id = hoaDon.MaHoaDon }, hoaDon);
        }

        // DELETE: api/HoaDon/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteHoaDon(string id)
        {
            if (_context.HoaDons == null)
            {
                return NotFound();
            }
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoaDonExists(string id)
        {
            return (_context.HoaDons?.Any(e => e.MaHoaDon == id)).GetValueOrDefault();
        }
    }
}
