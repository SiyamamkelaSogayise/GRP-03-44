using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations;
namespace GeeksProject02.Models
{
    public class NextMeetings
    {
        [Key]
        public int ChronicBookingID { get; set; }
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
