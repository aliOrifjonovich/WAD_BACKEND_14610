using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Data;
using WAD_BACKEND_14610.Models;
using WAD_BACKEND_14610.Repositories;

namespace WAD_BACKEND_14610.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAttendeesController : ControllerBase
    {
        private readonly IEventAttendeesRepository _eventAttendeessRepository;

        public EventAttendeesController(IEventAttendeesRepository eventAttendeessRepository)
        {
            _eventAttendeessRepository = eventAttendeessRepository;
        }

        // GET: api/EventAttendees
        [HttpGet]
        public async Task<IEnumerable<EventAttendees>> GetEventAttendeess()
        {
            return await _eventAttendeessRepository.GetEventAttendeess();
        }

        // GET: api/EventAttendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventAttendees>> GetEventAttendeesById(int id)
        {
            var eventAttendees = await _eventAttendeessRepository.GetEventAttendeesById(id);

            if (eventAttendees == null)
            {
                return NotFound();
            }

            return Ok(eventAttendees);
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

            try
            {
                await _eventAttendeessRepository.PutEventAttendees(eventAttendees);
            }
            catch (DbUpdateConcurrencyException)
            {
                var eventAttendeesSingle = await _eventAttendeessRepository.GetEventAttendeesById(id);
                if (eventAttendeesSingle == null)
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
            await _eventAttendeessRepository.PostEventAttendees(eventAttendees);

            return CreatedAtAction("GetEventAttendeess", new { id = eventAttendees.Id }, eventAttendees);
        }

        // DELETE: api/EventAttendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAttendees(int id)
        {
            await _eventAttendeessRepository.DeleteEventAttendees(id);

            return NoContent();
        }
    }
}
