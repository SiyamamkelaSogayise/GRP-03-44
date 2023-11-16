using System;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vaccine name is required.")]
        public string VaccineName { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Presentation is required.")]
        public string Presentation { get; set; }

        [Required(ErrorMessage = "Doses per box is required.")]
        public int DosesPerBox { get; set; }

        [Required(ErrorMessage = "Presentation box lot numbers are required.")]
        public string PresentationBoxLotNumbers { get; set; }

        [Required(ErrorMessage = "Presentation box expiration date is required.")]
        public DateTime PresentationBoxExpirationDate { get; set; }

        [Required(ErrorMessage = "Dose lot numbers are required.")]
        public string DoseLotNumbers { get; set; }

        [Required(ErrorMessage = "Dose expiration date is required.")]
        public DateTime DoseExpirationDate { get; set; }

        [Required(ErrorMessage = "Doses on hand is required.")]
        public int DosesOnHand { get; set; }

        [Required(ErrorMessage = "Total doses on hand is required.")]
        public int TotalDosesOnHand { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }
}
