using GeeksProject02.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class FamilyPlanningBookingUpdate
    {
        

        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Date of Booking Is Required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime DateOfBooking { get; set; }

        [Required(ErrorMessage = "Enter ID Number")]
        public string IDNumber { get; set; }

        [Required(ErrorMessage = "Reason For Booking Is Required")]
        public string BookingReason { get; set; }
    }
}
