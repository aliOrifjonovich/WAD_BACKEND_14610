using WAD_BACKEND_14610.Models;

namespace WAD_BACKEND_14610.Repositories
{
    public interface IEventManagementRepository
    {
        Task<IEnumerable<EventManagement>> GetEventManagements();
        Task<EventManagement> GetEventManagementById(int id);
        Task PostEventManagement(EventManagement eventManagement);
        Task PutEventManagement(EventManagement eventManagement);
        Task DeleteEventManagement(int id);
    }
}
