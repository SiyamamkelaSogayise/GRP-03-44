using GeeksProject02.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class ContactUs
    {
        public GeeksProject02User UserDetails { get; set; }
        public GeeksProject02User UserStatus { get; set; }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name  is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject  is required.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message  is required.")]
        public string Messages { get; set; }

    }
}
