using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_BACKEND_14610.Models
{
    public class EventAttendees
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "AttendeeName is required")]
        public string AttendeeName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "TicketType is required")]
        public TicketType TicketType { get; set; }

        public int? EventId { get; set; }

        [ForeignKey("EventId")]
        public EventManagement? EventManagement { get; set; }
    }
}

public enum TicketType
{
    VIP,
    Regular
}
