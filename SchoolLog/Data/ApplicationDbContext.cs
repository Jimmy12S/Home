using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeGreat.Model;



namespace SchoolLog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Gamtours;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
               // "Server=.\\SQLEXPRESS;Database=EFCore-SchoolDB;Trusted_Connection=True");
        }


        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EventStudent> EventStudents { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventStudent>().HasKey(sc => new { sc.StudentId, sc.EventId });

            modelBuilder.Entity<EventStudent>()
           .HasKey(t => new { t.EventId, t.StudentId });

            modelBuilder.Entity<EventStudent>()
                .HasOne(pt => pt.Event)
                .WithMany(p => p.EventStudents)
                .HasForeignKey(pt => pt.EventId);

            modelBuilder.Entity<EventStudent>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t.EventStudents)
                .HasForeignKey(pt => pt.EventId);
        }
    }
     

          }
    


