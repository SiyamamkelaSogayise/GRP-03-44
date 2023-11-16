using GeeksProject02.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksProject02.Models
{
    public class Appointments_P
    {
        //public GeeksProject02User UserDetails { get; set; }
        //public GeeksProject02User UserStatus { get; set; }

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

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime AppointmentDate { get; set; }

        public char Status { get; set; } = 'A';
    }
}
