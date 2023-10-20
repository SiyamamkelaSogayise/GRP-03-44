using GeeksProject02.Data;
using GeeksProject02.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Areas.Identity.Data
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext(DbContextOptions<PatientDBContext> options)
        : base(options)
        {
        }
        public DbSet<AddBooking> AddBookings { get; set; }
        public DbSet<PatientBooking> PatientBookings { get; set; }
    }

}
