using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class MedicalHistory
    {
        [Key]
        public int MedicalHistoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string DateOfBirth { get; set; }

        public string LifeStyle { get; set; }
        public string Allergies { get; set; }
        public string surgiersUndergone { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string PreviousMedication { get; set; }
        public string ImmunizationHistory { get; set; }
        public string Hospitalizations { get; set; }
        [Required]
        public string HomeTelePhoneNumber { get; set; }
        public string WorkTelePhoneNumber { get; set; }
        [Required]
        public string NextOfKinNumber { get; set; }
        public string InsurenceProvideNumber { get; set; }



    }
}
