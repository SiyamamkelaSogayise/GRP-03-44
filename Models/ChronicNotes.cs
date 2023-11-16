using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class ChronicNotes
    {
        [Key]
        public Guid Id { get; set; }

   
        [Required]
        public string Date { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]

        public string subject { get; set; }
        [Required]

        public string Message { get; set; }
        public string userId { get; set; }
    }
}
