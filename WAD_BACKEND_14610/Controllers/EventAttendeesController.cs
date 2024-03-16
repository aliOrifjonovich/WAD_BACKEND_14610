using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Data;
using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendeesController : ControllerBase
    {
        private readonly EventManagementDbContext _context;

        public EventAttendeesController(EventManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/EventAttendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventAttendees>>> GetEventAttendeess()
        {
          if (_context.EventAttendeess == null)
          {
              return NotFound();
          }
            return await _context.EventAttendeess.ToListAsync();
        }

        // GET: api/EventAttendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventAttendees>> GetEventAttendees(int id)
        {
          if (_context.EventAttendeess == null)
          {
              return NotFound();
          }
            var eventAttendees = await _context.EventAttendeess.FindAsync(id);

            if (eventAttendees == null)
            {
                return NotFound();
            }

            return eventAttendees;
        }

        // PUT: api/EventAttendees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventAttendees(int id, EventAttendees eventAttendees)
        {
            if (id != eventAttendees.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventAttendees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventAttendeesExists(id))
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

        // POST: api/EventAttendees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventAttendees>> PostEventAttendees(EventAttendees eventAttendees)
        {
          if (_context.EventAttendeess == null)
          {
              return Problem("Entity set 'EventManagementDbContext.EventAttendeess'  is null.");
          }
            _context.EventAttendeess.Add(eventAttendees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventAttendees", new { id = eventAttendees.Id }, eventAttendees);
        }

        // DELETE: api/EventAttendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAttendees(int id)
        {
            if (_context.EventAttendeess == null)
            {
                return NotFound();
            }
            var eventAttendees = await _context.EventAttendeess.FindAsync(id);
            if (eventAttendees == null)
            {
                return NotFound();
            }

            _context.EventAttendeess.Remove(eventAttendees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventAttendeesExists(int id)
        {
            return (_context.EventAttendeess?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
