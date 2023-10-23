﻿using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class PatientBooking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string AdditionalInfo { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public bool IsMedicalAidMember { get; set; }
        [Required]
        public string MedicalAidNumber { get; set; }
        [Required]
        public string MedicalAidName { get; set; }
    }
}
