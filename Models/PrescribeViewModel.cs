using GeeksProject02.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class PrescribeViewModel
    {
        public GeeksProject02User UserDetails { get; set; }
        public GeeksProject02User UserStatus { get; set; }
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
    }
}
