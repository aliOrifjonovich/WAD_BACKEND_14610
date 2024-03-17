using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Repositories
{
    public interface IEventAttendeesRepository
    {
        Task<IEnumerable<EventAttendees>> GetEventAttendeess();
        Task<EventAttendees> GetEventAttendeesById(int id);
        Task PostEventAttendees(EventAttendees eventAttendees);
        Task PutEventAttendees(EventAttendees eventAttendees);
        Task DeleteEventAttendees(int id);
    }
}
