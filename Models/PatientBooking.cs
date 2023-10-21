namespace GeeksProject02.Models
{
    public class PatientBooking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsMedicalAidMember { get; set; }
        public string MedicalAidNumber { get; set; }
        public string MedicalAidName { get; set; }
    }
}
