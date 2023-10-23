using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Appointments: PageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]

        public string EmailAddress { get; set; }

        [Required]

        public string PhoneNumber { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime AppointmentDate { get; set; }

        [Required]
        public bool IsMedicalAidMember { get; set; }

       
        public string MedicalAidNumber { get; set; }

        
        public string MedicalAidName { get; set; }
    }
}
