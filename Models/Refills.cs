using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class Refills
    {
        [Key]
        public int refillID { get; set; }
        [Required]
        public string RefillReason { get; set; }
        [Required]

        public string durationOfTheSituation { get; set; }
    }
}
