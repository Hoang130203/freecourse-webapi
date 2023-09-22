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
    public class RapController : ControllerBase
    {
        private readonly ProjectContext _context;

        public RapController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Rap
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Rap>>> GetRaps()
        {
          if (_context.Raps == null)
          {
              return NotFound();
          }
            return await _context.Raps.ToListAsync();
        }

        // GET: api/Rap/5
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Rap>> GetRap(string id)
        {
          if (_context.Raps == null)
          {
              return NotFound();
          }
            var rap = await _context.Raps.FindAsync(id);

            if (rap == null)
            {
                return NotFound();
            }

            return rap;
        }

        // PUT: api/Rap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutRap(string id, Rap rap)
        {
            if (id != rap.MaRap)
            {
                return BadRequest();
            }

            _context.Entry(rap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RapExists(id))
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

        // POST: api/Rap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public async Task<ActionResult<Rap>> PostRap(Rap rap)
        {
          if (_context.Raps == null)
          {
              return Problem("Entity set 'ProjectContext.Raps'  is null.");
          }
            _context.Raps.Add(rap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RapExists(rap.MaRap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRap", new { id = rap.MaRap }, rap);
        }

        // DELETE: api/Rap/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRap(string id)
        {
            if (_context.Raps == null)
            {
                return NotFound();
            }
            var rap = await _context.Raps.FindAsync(id);
            if (rap == null)
            {
                return NotFound();
            }

            _context.Raps.Remove(rap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RapExists(string id)
        {
            return (_context.Raps?.Any(e => e.MaRap == id)).GetValueOrDefault();
        }
    }
}
