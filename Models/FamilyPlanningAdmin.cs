using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class FamilyPlanningAdmin
    {
        // Personal Information
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string GenderIdentity { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        // Insurance Information
        [Required]
        public string InsuranceProvider { get; set; }
        [Required]
        public string PolicyNumber { get; set; }
        [Required]
        public string GroupID { get; set; }


        // Medical History
        [Required]
        public string ExistingMedicalConditions { get; set; }
        [Required]
        public string Allergies { get; set; }
        [Required]
        public string CurrentMedications { get; set; }
        [Required]
        public string SurgicalHistory { get; set; }

        // Reproductive Health History
        [Required]
        public string MenstrualHistory { get; set; }
        [Required]
        public string PregnancyHistory { get; set; }
        [Required]
        public string ContraceptiveHistory { get; set; }
        [Required]
        public string STIHistory { get; set; }

        // Emergency Contact Information
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        public string EmergencyContactRelationship { get; set; }
        [Required]
        public string EmergencyContactPhoneNumber { get; set; }

        // Preferred Doctor or Provider
        [Required]
        public string PreferredDoctor { get; set; }

        // Other methods
    }
}
