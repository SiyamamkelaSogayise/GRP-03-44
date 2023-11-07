using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class QuestionnaireResponse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AllergicReaction { get; set; }
        [Required]
        public string AnotherAllergicReaction { get; set; }
        [Required]
        public string Pregnant { get; set; }
        [Required]
        public string Breastfeeding { get; set; }
        [Required]
        public string WeakenedImmuneSystem { get; set; }
        [Required]
        public string PreviousVaccine { get; set; }
        [Required]
        public string CovidSymptoms { get; set; }
        [Required]
        public string CloseContact { get; set; }
        [Required]
        public string OtherVaccines { get; set; }
        [Required]
        public string HealthConditions { get; set; }
    }
}
