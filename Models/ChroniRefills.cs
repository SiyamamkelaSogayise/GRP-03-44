using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class ChroniRefills
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string RefillReason { get; set; }
        [Required]

        public string durationOfTheSituation { get; set; }
        public string userId { get; set; }
    }
}
