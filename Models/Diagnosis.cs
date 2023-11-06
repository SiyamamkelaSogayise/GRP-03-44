using Microsoft.CodeAnalysis;
using NuGet.Protocol.Plugins;
using System.Net;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class Diagnosis
    {

        [Key]
        public int DiagnosisID { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PrimarySymptoms { get; set; }
        [Required]
        public string SecondarySymptoms { get; set; }
        [Required]
        public string Severity { get; set; }
        [Required]
        public string BloodPressure { get; set; }
        [Required]
        public string HeartRate { get; set; }
        [Required]
        public string RespirationRate { get; set; }
        [Required]
        public string Temperature { get; set; }
        [Required]
        public string DiagnosisResults { get; set; }
        [Required]
        public string TreatmentPlan { get; set; }
        [Required]
        public string FollowupInstructions { get; set; }
        [Required]
        public string PhysicianName { get; set; }
        [Required]
        public string Hospital { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string SignatureByName { get; set; }
    }
}
