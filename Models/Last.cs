using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksProject02.Models
{
    public class Last
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Additional information is required.")]
        public string AdditionalInfo { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please select a Medical Aid status.")]
        public bool IsMedicalAidMember { get; set; }

        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNumber { get; set; }

        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please select a vaccine.")]
        public List<SelectListItem> VaccineList { get; set; }

        [Required(ErrorMessage = "Please select a vaccine.")]
        public string SelectedVaccine { get; set; }
    }
}
