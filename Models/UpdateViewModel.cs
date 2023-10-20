namespace GeeksProject02.Models
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public List<AvailableDay>? AvailableDays { get; set; }
        public List<PreferredAppointmentTime>? PreferredAppointmentTime { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsMedicalAidMember { get; set; }
    }
}
