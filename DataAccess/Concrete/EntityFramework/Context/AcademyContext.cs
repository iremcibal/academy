using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AcademyContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6HHUABE\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>(a =>
            {
                a.ToTable("applicants").HasKey("id");
                a.Property(a =>a.Id).HasColumnName("id");
                a.Property(a => a.About).HasColumnName("about");
            });

            modelBuilder.Entity<Application>(a =>
            {
                a.ToTable("applications").HasKey("id");
                a.Property(a => a.Id).HasColumnName("id");
                a.Property(a => a.StateId).HasColumnName("state_id");
                a.Property(a => a.BootcampId).HasColumnName("bootcamp_id");
                a.Property(a => a.ApplicantId).HasColumnName("applicant_id");
                a.HasOne(a => a.State);
                a.HasOne(a => a.Bootcamp);
                a.HasOne(a => a.Applicant);
            });

            modelBuilder.Entity<Blacklist>(b =>
            {
                b.ToTable("blacklists").HasKey("id");
                b.Property(b => b.Id).HasColumnName("id");
                b.Property(b => b.Reason).HasColumnName("reason");
                b.Property(b => b.date).HasColumnName("date");
                b.Property(b => b.ApplicantId).HasColumnName("applicant_id");
                b.HasOne(b => b.Applicant);
            });

            modelBuilder.Entity<Bootcamp>(b =>
            {
                b.ToTable("bootcamps").HasKey("id");
                b.Property(b => b.Id).HasColumnName("id");
                b.Property(b => b.Name).HasColumnName("name");
                b.Property(b => b.State).HasColumnName("state");
                b.Property(b => b.StartDate).HasColumnName("start_date");
                b.Property(b => b.EndDate).HasColumnName("end_date");
                b.Property(b => b.InstructorId).HasColumnName("instructor_id");
                b.HasOne(b => b.Instructor);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("employees").HasKey("id");
                e.Property(e => e.Id).HasColumnName("id");
                e.Property(e => e.Position).HasColumnName("position");
            });

            modelBuilder.Entity<Instructor>(i =>
            {
                i.ToTable("instructors").HasKey("id");
                i.Property(i => i.Id).HasColumnName("id");
                i.Property(i => i.CompanyName).HasColumnName("company_name");
            });

            modelBuilder.Entity<State>(s =>
            {
                s.ToTable("states").HasKey("id");
                s.Property(s => s.Id).HasColumnName("id");
                s.Property(s => s.Info).HasColumnName("info");
            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("users").HasKey("id");
                u.Property(u => u.Id).HasColumnName("id");
                u.Property(u => u.FirstName).HasColumnName("first_name");
                u.Property(u => u.LastName).HasColumnName("last_name");
                u.Property(u => u.NationalIdentity).HasColumnName("national_identity");
                u.Property(u => u.DateOfBirth).HasColumnName("date_of_birth");
                u.Property(u => u.Email).HasColumnName("email");
                u.Property(u => u.Password).HasColumnName("password");
            });
        }
    }
}
