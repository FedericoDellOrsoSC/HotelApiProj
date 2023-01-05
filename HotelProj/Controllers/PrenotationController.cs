using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelProj.Models;

namespace HotelProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotationController : ControllerBase
    {
        private readonly RoomContext _context;

        public PrenotationController(RoomContext context)
        {
            _context = context;
        }

        // GET: api/Prenotation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prenotation>>> Getprenotations()
        {
          if (_context.prenotations == null)
          {
              return NotFound();
          }
            return await _context.prenotations.ToListAsync();
        }

        // GET: api/Prenotation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prenotation>> GetPrenotation(long id)
        {
          if (_context.prenotations == null)
          {
              return NotFound();
          }
            var prenotation = await _context.prenotations.FindAsync(id);

            if (prenotation == null)
            {
                return NotFound();
            }

            return prenotation;
        }

        // GET: api/Prenotation/room/RoomId
        [HttpGet("room/{RoomId}")]
        public async Task<ActionResult<List<Prenotation>>> GetPrenotationbyRoom(int RoomId)
        {
            if (_context.prenotations == null)
            {
                return NotFound();
            }
            var prenotationlistByRoom = _context.prenotations.Where(prenotation => prenotation.roomId==RoomId).ToList();

            if (!prenotationlistByRoom.Any())
            {
                return NotFound();
            }

            return prenotationlistByRoom;
        }

        // GET: api/Prenotation/guest/{guestID}
        [HttpGet("guest/{GuestId}")]
        public async Task<ActionResult<List<Prenotation>>> GetPrenotationbyGuest(int GuestId)
        {
            if (_context.prenotations == null)
            {
                return NotFound();
            }
            var prenotationlistByGuest = _context.prenotations.Where(prenotation => prenotation.roomId == GuestId).ToList();

            if (!prenotationlistByGuest.Any())
            {
                return NotFound();
            }


            return prenotationlistByGuest;
        }

        // PUT: api/Prenotation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrenotation(long id, Prenotation prenotation)
        {
            if (id != prenotation.Id)
            {
                return BadRequest();
            }

            _context.Entry(prenotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrenotationExists(id))
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

        // POST: api/Prenotation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prenotation>> PostPrenotation(Prenotation prenotation)
        {
          if (_context.prenotations == null)
          {
              return Problem("Entity set 'RoomContext.prenotations'  is null.");
          }
            _context.prenotations.Add(prenotation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrenotation", new { id = prenotation.Id }, prenotation);
        }

        // DELETE: api/Prenotation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrenotation(long id)
        {
            if (_context.prenotations == null)
            {
                return NotFound();
            }
            var prenotation = await _context.prenotations.FindAsync(id);
            if (prenotation == null)
            {
                return NotFound();
            }

            _context.prenotations.Remove(prenotation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrenotationExists(long id)
        {
            return (_context.prenotations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
