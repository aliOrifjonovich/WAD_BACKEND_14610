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
    public class EventManagementsController : ControllerBase
    {
        private readonly EventManagementDbContext _context;

        public EventManagementsController(EventManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/EventManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventManagement>>> GetEventManagements()
        {
          if (_context.EventManagements == null)
          {
              return NotFound();
          }
            return await _context.EventManagements.ToListAsync();
        }

        // GET: api/EventManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventManagement>> GetEventManagement(int id)
        {
          if (_context.EventManagements == null)
          {
              return NotFound();
          }
            var eventManagement = await _context.EventManagements.FindAsync(id);

            if (eventManagement == null)
            {
                return NotFound();
            }

            return eventManagement;
        }

        // PUT: api/EventManagements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventManagement(int id, EventManagement eventManagement)
        {
            if (id != eventManagement.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventManagementExists(id))
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

        // POST: api/EventManagements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventManagement>> PostEventManagement(EventManagement eventManagement)
        {
          if (_context.EventManagements == null)
          {
              return Problem("Entity set 'EventManagementDbContext.EventManagements'  is null.");
          }
            _context.EventManagements.Add(eventManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventManagement", new { id = eventManagement.Id }, eventManagement);
        }

        // DELETE: api/EventManagements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventManagement(int id)
        {
            if (_context.EventManagements == null)
            {
                return NotFound();
            }
            var eventManagement = await _context.EventManagements.FindAsync(id);
            if (eventManagement == null)
            {
                return NotFound();
            }

            _context.EventManagements.Remove(eventManagement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventManagementExists(int id)
        {
            return (_context.EventManagements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
