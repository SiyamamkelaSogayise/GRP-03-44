using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Pregnancy_Tracker
    {
        [Key]
        public int pregnancy_ID { get; set; }

        [Required]
        public DateTime last_period { get; set; }

        [Required]
        public DateTime delivery_date { get; set; }

        [Required]
        public int current_week { get; set; }

        [Required]
        public int current_day { get; set; }
    }
}
