using System.ComponentModel;
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

        [Required(ErrorMessage = "Additional information is required.")]
        public string AboutYourself { get; set; }

        [Required(ErrorMessage = "Baby's Name is required.")]
        public string BabyName { get; set; }

        [Required(ErrorMessage = "Baby's Age is required")]
        [MinimumAge(8)]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BabyBirth { get; set; }

        public char Status { get; set; } = 'A';
    }
}
