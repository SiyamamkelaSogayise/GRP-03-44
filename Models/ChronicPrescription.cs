using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class ChronicPrescription
    {
        [Key]
        public int ChronicPrescriptionID { get; set; }
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
