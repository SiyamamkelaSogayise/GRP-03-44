using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VaccineName { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Presentation { get; set; }

        [Required]
        public int DosesPerBox { get; set; }

        [Required]
        public string PresentationBoxLotNumbers { get; set; }

        [Required]
        public DateTime PresentationBoxExpirationDate { get; set; }

        [Required]
        public string DoseLotNumbers { get; set; }

        [Required]
        public DateTime DoseExpirationDate { get; set; }

        [Required]
        public int DosesOnHand { get; set; }

        [Required]
        public int TotalDosesOnHand { get; set; }

        [Required]
        public string Status { get; set; }
       

    }
}
