using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace GeeksProject02.Models
{
    public class Patient
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
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string AdditionalInfo { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public bool IsMedicalAidMember { get; set; }
        [Required]
        public string MedicalAidNumber { get; set; }
        [Required]
        public string MedicalAidName { get; set; }

        public Form Form { get; set; }
    }
}
