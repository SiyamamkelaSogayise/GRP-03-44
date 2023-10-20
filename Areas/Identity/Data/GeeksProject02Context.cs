using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeeksProject02.Data;

public class GeeksProject02Context : IdentityDbContext<GeeksProject02User>
{
    public GeeksProject02Context(DbContextOptions<GeeksProject02Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    //public DbSet<SuperVillains1> SuperVillians { get; set; }

    public DbSet<Patient_Info> Patient_Info { get; set; }
    public DbSet<Pregnancy_Tracker> Pregnancy_Tracker { get; set; }

    


    public DbSet<MedicalHistory> ChronicMedicalHistory { get; set; }
    public DbSet<ChronicBooking> BookingChronic { get; set; }
}
