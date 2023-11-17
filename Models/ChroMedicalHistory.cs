using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class ChroMedicalHistory
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

       

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Please enter a valid mobile number.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "LifeStyle is required.")]
        public string LifeStyle { get; set; }
        public string Allergies { get; set; }
        public string surgiersUndergone { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string PreviousMedication { get; set; }
        public string ImmunizationHistory { get; set; }
        public string Hospitalizations { get; set; }
        
        public string HomeTelePhoneNumber { get; set; }
        public string WorkTelePhoneNumber { get; set; }
       
        public string NextOfKinNumber { get; set; }
        public string InsurenceProvideNumber { get; set; }
        public string userId { get; set; }
    }
}
