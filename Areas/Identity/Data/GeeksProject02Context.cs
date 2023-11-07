﻿using GeeksProject02.Areas.Identity.Data;
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
    public DbSet<GeeksProject02User> GeeksProject02Users { get; set; }
    public GeeksProject02Context(string connectionString)
    {
        ConnectionString = connectionString;
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<Form>()
    //             .Property(f => f.Status)
    //             .HasConversion(
    //                 status => status.ToString(),  // Convert enum to string when saving to the database
    //                 statusStr => (Form.AppointmentStatus)Enum.Parse(typeof(Form.AppointmentStatus), statusStr) // Convert string to enum when reading from the database
    //    );

    //    builder.Entity<Form>()
    //    .HasOne(f => f.UserAppointment)
    //    .WithMany()
    //    .HasForeignKey(f => f.AppointmentId);

    //    base.OnModelCreating(builder);
    //}
    //public DbSet<SuperVillains1> SuperVillians { get; set; }

    public DbSet<Patient_Info> Patient_Info { get; set; }
    public DbSet<Pregnancy_Tracker> Pregnancy_Tracker { get; set; }


    public DbSet<MedicalHistory> ChronicMedicalHistory { get; set; }

    //public DbSet<ChronicBooking> BookingChronic { get; set; }
    

    //public DbSet<ChronicBooking> BookingChronic { get; set; }


    //public DbSet<MedicalHistory> ChronicMedicalHistory { get; set; }
    //public DbSet<ChronicBooking> BookingChronic { get; set; }


    
    public string ConnectionString { get; }
    public DbSet<Last> Lasts { get; set; }
<<<<<<< HEAD
    public DbSet <QuestionnaireResponse> QuestionnaireResponses { get; set;}
=======

    public DbSet<ChronicPrescription>ChronicPrescriptions { get; set; }
    public DbSet<Notes>Notes { get; set; }
    public DbSet<Diagnosis> Diagnosis { get; set; }
    public DbSet<NextMeetings> NextMeetings { get; set; }
    
>>>>>>> 39dd1ceaf8aadb6e4198c4e03aa5159797f6b147
}
