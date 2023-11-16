using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class ChronicNextMeeting
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ChronicBookingDate { get; set; }
        [Required]
        public string chronicBookingTime { get; set; }
        [Required]
        public string ChronicReason { get; set; }
        [Required]
        public string SignitureByName { get; set; }
        public string userId { get; set; }
    }
}
