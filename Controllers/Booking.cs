namespace GeeksProject02.Controllers
{
    internal class Booking
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Preference { get; set; }
        public bool ForDependent { get; set; }
    }
}