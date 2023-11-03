using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Last
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string AdditionalInfo { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public bool IsMedicalAidMember { get; set; }

        public string MedicalAidNumber { get; set; }

        public string MedicalAidName { get; set; }
    }
}
