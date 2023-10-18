using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Patient_Info
    {
        [Key]
        public int patient_ID { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public bool role { get; set; }
    }
}
