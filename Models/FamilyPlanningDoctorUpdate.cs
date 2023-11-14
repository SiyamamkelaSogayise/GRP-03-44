namespace GeeksProject02.Models
{
    public class FamilyPlanningDoctorUpdate
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OfNote { get; set; }
        public string ProviderName { get; set; }
        public string ReasonForVisit { get; set; }
        public string Examination { get; set; }
        public string EncounterSummary { get; set; }
        public string Prescription { get; set; }
    }
}
