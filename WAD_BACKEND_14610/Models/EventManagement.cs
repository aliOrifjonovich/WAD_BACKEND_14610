using System.ComponentModel.DataAnnotations;

namespace WAD_BACKEND_14610.Models
{
    public class EventManagement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EventName is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public string Venue { get; set; }

        private string _organizer;

        public string Organizer
        {
            get => _organizer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Organizer cannot be null or empty.");
                }

                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException("Organizer must start with a capital letter.");
                }

                _organizer = value;
            }
        }
    }
}
