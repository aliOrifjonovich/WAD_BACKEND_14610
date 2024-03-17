

using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Data;
using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Repositories
{
    public class EventManagementRepository : IEventManagementRepository
    {
        private readonly EventManagementDbContext _dbContext;

        public EventManagementRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task DeleteEventManagement(int id)
        {
            var eventManagement = await _dbContext.EventManagements.FirstOrDefaultAsync(m => m.Id == id);

            if (eventManagement != null)
            {
                _dbContext.EventManagements.Remove(eventManagement);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<EventManagement> GetEventManagementById(int id)
        {
            return await _dbContext.EventManagements.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<EventManagement>> GetEventManagements()
        {
            return await _dbContext.EventManagements.ToListAsync();
        }

        public async Task PostEventManagement(EventManagement eventManagement)
        {
            await _dbContext.EventManagements.AddAsync(eventManagement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutEventManagement(EventManagement eventManagement)
        {
            _dbContext.Entry(eventManagement).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
