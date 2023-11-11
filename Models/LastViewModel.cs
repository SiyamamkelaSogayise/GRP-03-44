using GeeksProject02.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class LastViewModel
    {
        public GeeksProject02User UserDetails { get; set; }
        public GeeksProject02User UserStatus { get; set; }

        

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string AdditionalInfo { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public int SelectedVaccineId { get; set; }
        public List<Stock> AvailableVaccines { get; set; } = new List<Stock>();
        [Required]
        public bool IsMedicalAidMember { get; set; }

        public string MedicalAidNumber { get; set; }

        public string MedicalAidName { get; set; }
    }
}
