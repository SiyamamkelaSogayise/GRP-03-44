using GeeksProject02.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GeeksProject02.Models
{
    public class NextMeetingViewModel
    {
        public GeeksProject02User UserDetails { get; set; }
        public GeeksProject02User UserStatus { get; set; }
        [Required]
        public string ChronicBookingDate { get; set; }
        [Required]
        public string chronicBookingTime { get; set; }
        [Required]
        public string ChronicReason { get; set; }
        [Required]
        public string SignitureByName { get; set; }
    }
}
