using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class ChroPrescribe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string LicenceNUmber { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]

        public string MedicationName { get; set; }
        [Required]
        public string DosageInstruction { get; set; }
        [Required]
        public string Signiture { get; set; }
        public string userId { get; set; }
    }
}
