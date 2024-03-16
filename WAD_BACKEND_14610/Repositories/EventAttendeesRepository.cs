using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Data;
using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Repositories
{
    public class EventAttendeesRepository : IEventAttendeesRepository
    {

        private readonly EventManagementDbContext _dbContext;

        public EventAttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteEventAttendees(int id)
        {
            var eventAttendees = await _dbContext.EventAttendeess.FirstOrDefaultAsync(a => a.Id == id);

            if (eventAttendees != null)
            {
                _dbContext.EventAttendeess.Remove(eventAttendees);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventAttendees> GetEventAttendeesById(int id)
        {
            return await _dbContext.EventAttendeess.Include(a => a.EventManagement).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<EventAttendees>> GetEventAttendeess()
        {
            return await _dbContext.EventAttendeess.Include(a => a.EventManagement).ToListAsync();
        }

        public async Task PostEventAttendees(EventAttendees eventAttendees)
        {
            await _dbContext.EventAttendeess.AddAsync(eventAttendees);
            await _dbContext.SaveChangesAsync();
        }


        public async Task PutEventAttendees(EventAttendees eventAttendees)
        {
            _dbContext.Entry(eventAttendees).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
