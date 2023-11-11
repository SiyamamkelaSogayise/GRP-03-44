using GeeksProject02.Areas.Identity.Data;
using GeeksProject02.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GeeksProject02.Data;

public class GeeksProject02Context : IdentityDbContext<GeeksProject02User>
{
    public GeeksProject02Context(DbContextOptions<GeeksProject02Context> options)
        : base(options)
    {
    }
    
    

    public DbSet<Patient_Info> Patient_Info { get; set; }
    public DbSet<Pregnancy_Tracker> Pregnancy_Tracker { get; set; }


    public DbSet<MedicalHistory> ChronicMedicalHistory { get; set; }
    public DbSet<AvailableVaccine> AvailableVaccines { get; set; }

   


    public DbSet<GeeksProject02User> GeeksProject02Users { get; set; }
    public DbSet<Last> Lasts { get; set; }

    public DbSet <QuestionnaireResponse> QuestionnaireResponses { get; set;}


    public DbSet<ChronicPrescription>ChronicPrescriptions { get; set; }
    public DbSet<Notes>Notes { get; set; }
    public DbSet<Diagnosis> Diagnosis { get; set; }
    public DbSet<NextMeetings> NextMeetings { get; set; }
   public DbSet<Stock> Stocks { get; set; }
    

}
