using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksProject02.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        
        public string EmailAddress { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }

        [Required]
        public string AdditionalInfo { get; set; }

        [Required]
        
        public DateTime AppointmentDate { get; set; }

        [Required]
        public bool IsMedicalAidMember { get; set; }

        
        public string MedicalAidNumber { get; set; }

        
        public string MedicalAidName { get; set; }

        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Patient UserAppointment { get; set; }

        public enum AppointmentStatus
        {
            Pending,
            Accepted,
            Declined
        }
        public AppointmentStatus Status { get; set; }
    }
    
}

