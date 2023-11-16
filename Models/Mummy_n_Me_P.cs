using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class Mummy_n_Me_P
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Additional information is required.")]
        public string AdditionalInfo { get; set; }

        public char Status { get; set; } = 'A';
    }
}
