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


        [Required(ErrorMessage = "Organizer is required")]
        [OrganizerValidation(ErrorMessage = "Organizer name must start with a capital letter")]
        public string Organizer { get; set; }
    }
}

public class OrganizerValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string organizerName = value.ToString();
            if (!char.IsUpper(organizerName[0]))
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}