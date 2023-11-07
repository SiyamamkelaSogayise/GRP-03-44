using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class Notes
    {
        [Key]
        public int NotesID { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]

        public string subject { get; set; }
        [Required]

        public string Message { get; set; }
    }
}

