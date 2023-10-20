using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class ChronicBooking
    {
        [Key]
        public int BookingID { get; set; }
        [Required]
        public string BookingName { get; set; }
        [Required]
        public string BookingEmail { get; set; }
        [Required]
        public string BookingDate { get; set; }

        public string PreferredGenderConsultant { get; set; }
    }
}
