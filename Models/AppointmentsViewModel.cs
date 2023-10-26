using System.ComponentModel.DataAnnotations;

namespace GeeksProject02.Models
{
    public class AppointmentsViewModel
    {
        public List<Patient> UserData { get; set; } // Property for user data
        public List<Form> AdminData { get; set; }   // Property for admin data
    
         [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string AdditionalInfo { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool IsMedicalAidMember { get; set; }

        public string MedicalAidNumber { get; set; }

        public string MedicalAidName { get; set; }

        public Form.AppointmentStatus Status { get; set; }
    }
}
