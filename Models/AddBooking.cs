using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
   
    public class AddBooking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public bool IsMedicalAidMember { get; set; }
    }

}
