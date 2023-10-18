using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GeeksProject02.Models
{
    public class BookingChronic
    {
        [Key]
        public int BookingID { get; set; }
        
        public string PreferredGenderConsultant { get; set; }
        [Required]
        public string BookingDate { get; set; }

        [Required] 

        public string BookingTime { get; set; }
    }
}
