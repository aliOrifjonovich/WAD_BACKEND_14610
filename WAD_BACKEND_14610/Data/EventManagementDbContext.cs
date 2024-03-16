using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Data
{
    public class EventManagementDbContext : DbContext
    {
        public EventManagementDbContext(DbContextOptions<EventManagementDbContext> options) : base(options) { }

        public DbSet<EventManagement> EventManagements { get; set; }
        public DbSet<EventAttendees> EventAttendeess { get; set; }
    }
}
