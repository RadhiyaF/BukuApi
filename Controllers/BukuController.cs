using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crudbuku.Models;

namespace crudbuku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {
        private readonly BooksContext _context;

        public BukuController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/Buku
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buku>>> GetBuku()
        {
          if (_context.Buku == null)
          {
              return NotFound();
          }
            return await _context.Buku.ToListAsync();
        }

        // GET: api/Buku/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buku>> GetBuku(long id)
        {
          if (_context.Buku == null)
          {
              return NotFound();
          }
            var buku = await _context.Buku.FindAsync(id);

            if (buku == null)
            {
                return NotFound();
            }

            return buku;
        }

        // PUT: api/Buku/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuku(long id, Buku buku)
        {
            if (id != buku.Id)
            {
                return BadRequest();
            }

            _context.Entry(buku).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BukuExists(id))
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

        // POST: api/Buku
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buku>> PostBuku(Buku buku)
        {
          if (_context.Buku == null)
          {
              return Problem("Entity set 'BooksContext.Buku'  is null.");
          }
            _context.Buku.Add(buku);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuku", new { id = buku.Id }, buku);
        }

        // DELETE: api/Buku/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuku(long id)
        {
            if (_context.Buku == null)
            {
                return NotFound();
            }
            var buku = await _context.Buku.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }

            _context.Buku.Remove(buku);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BukuExists(long id)
        {
            return (_context.Buku?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
