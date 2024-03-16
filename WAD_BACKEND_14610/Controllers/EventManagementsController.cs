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
    public class EventManagementsController : ControllerBase
    {
        private readonly IEventManagementRepository _eventManagementsRepository;

        public EventManagementsController(IEventManagementRepository eventManagementsRepository)
        {
            _eventManagementsRepository = eventManagementsRepository;
        }

        // GET: api/EventManagements
        [HttpGet]
        public async Task<IEnumerable<EventManagement>> GetEventManagements()
        {
            return await _eventManagementsRepository.GetEventManagements();
        }

        // GET: api/EventManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventManagement>> GetEventManagementById(int id)
        {
            var eventManagement = await _eventManagementsRepository.GetEventManagementById(id);

            if (eventManagement == null)
            {
                return NotFound();
            }

            return Ok(eventManagement);
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

            try
            {
                await _eventManagementsRepository.PutEventManagement(eventManagement);
            }
            catch (DbUpdateConcurrencyException)
            {
                var eventManagementSingle = await _eventManagementsRepository.GetEventManagementById(id);
                if (eventManagementSingle == null)
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
            await _eventManagementsRepository.PostEventManagement(eventManagement);

            return CreatedAtAction("GetEventManagements", new { id = eventManagement.Id }, eventManagement);
        }

        // DELETE: api/EventManagements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventManagement(int id)
        {
            await _eventManagementsRepository.DeleteEventManagement(id);

            return NoContent();
        }
    }
}
