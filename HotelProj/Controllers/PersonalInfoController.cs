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
    public class PersonalInfoController : ControllerBase
    {
        private readonly RoomContext _context;

        public PersonalInfoController(RoomContext context)
        {
            _context = context;
        }

        // GET: api/PersonalInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfo>>> GetPersonalInfos()
        {
          if (_context.PersonalInfos == null)
          {
              return NotFound();
          }
            return await _context.PersonalInfos.ToListAsync();
        }

        // GET: api/PersonalInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfo>> GetPersonalInfo(long id)
        {
          if (_context.PersonalInfos == null)
          {
              return NotFound();
          }
            var personalInfo = await _context.PersonalInfos.FindAsync(id);

            if (personalInfo == null)
            {
                return NotFound();
            }

            return personalInfo;
        }

        // PUT: api/PersonalInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalInfo(long id, PersonalInfo personalInfo)
        {
            if (id != personalInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInfoExists(id))
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

        // POST: api/PersonalInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalInfo>> PostPersonalInfo(PersonalInfo personalInfo)
        {
          if (_context.PersonalInfos == null)
          {
              return Problem("Entity set 'RoomContext.PersonalInfos'  is null.");
          }
            _context.PersonalInfos.Add(personalInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInfo", new { id = personalInfo.Id }, personalInfo);
        }

        // DELETE: api/PersonalInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalInfo(long id)
        {
            if (_context.PersonalInfos == null)
            {
                return NotFound();
            }
            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            if (personalInfo == null)
            {
                return NotFound();
            }

            _context.PersonalInfos.Remove(personalInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalInfoExists(long id)
        {
            return (_context.PersonalInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
