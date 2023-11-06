namespace GeeksProject02.Models
{
    public class FamilyPlanningAdmin
    {
        // Personal Information
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string GenderIdentity { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Insurance Information
        public string InsuranceProvider { get; set; }
        public string PolicyNumber { get; set; }
        public string GroupID { get; set; }

        // Medical History
        public string ExistingMedicalConditions { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string SurgicalHistory { get; set; }

        // Reproductive Health History
        public string MenstrualHistory { get; set; }
        public string PregnancyHistory { get; set; }
        public string ContraceptiveHistory { get; set; }
        public string STIHistory { get; set; }

        // Emergency Contact Information
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }

        // Preferred Doctor or Provider
        public string PreferredDoctor { get; set; }

        // Other methods
    }
}
