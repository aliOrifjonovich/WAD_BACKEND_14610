using Microsoft.EntityFrameworkCore;

namespace WAD_BACKEND_14610.Data
{
    public class EventManagementDbContext : DbContext
    {
        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options) : base(options) { }
    }
}
