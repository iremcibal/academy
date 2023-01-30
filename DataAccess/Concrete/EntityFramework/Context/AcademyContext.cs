using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AcademyContext : DbContext
    {
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Application> applications { get; set; }
        public DbSet<Blacklist> blacklists { get; set; }
        public DbSet<Bootcamp> bootcamps { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<User> users { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6HHUABE\MSSQLSERVER01;Database=academy;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder.UseNpgsql("Host=localhost; Database=academy; Username=postgres; Password=12345");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("users").HasKey("Id");
                u.Property(u => u.Id).HasColumnName("Id");
                u.Property(u => u.FirstName).HasColumnName("first_name");
                u.Property(u => u.LastName).HasColumnName("last_name");
                u.Property(u => u.NationalIdentity).HasColumnName("national_identity");
                u.Property(u => u.DateOfBirth).HasColumnName("date_of_birth");
                u.Property(u => u.Email).HasColumnName("email");
                u.Property(u => u.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Applicant>(a =>
            {
                a.ToTable("applicants").HasKey("Id");
                a.Property(u=>u.Id).HasColumnName("Id");
                a.Property(a => a.About).HasColumnName("about");
            });

            modelBuilder.Entity<Application>(a =>
            {
                a.ToTable("applications").HasKey("Id");
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
                b.ToTable("blacklists").HasKey("Id");
                b.Property(b => b.Id).HasColumnName("id");
                b.Property(b => b.Reason).HasColumnName("reason");
                b.Property(b => b.date).HasColumnName("date");
                b.Property(b => b.ApplicantId).HasColumnName("applicant_id");
                b.HasOne(b => b.Applicant);
            });

            modelBuilder.Entity<Bootcamp>(b =>
            {
                b.ToTable("bootcamps").HasKey("Id");
                b.Property(b => b.Id).HasColumnName("Id");
                b.Property(b => b.Name).HasColumnName("name");
                b.Property(b => b.StartDate).HasColumnName("start_date");
                b.Property(b => b.EndDate).HasColumnName("end_date");
                b.Property(b => b.StateId).HasColumnName("state_id");
                b.Property(b => b.InstructorId).HasColumnName("instructor_id");
                b.HasOne(b => b.State);
                b.HasOne(b => b.Instructor);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("employees").HasKey("Id");
                e.Property(e => e.Id).HasColumnName("Id");
                e.Property(e => e.Position).HasColumnName("position");
            });

            modelBuilder.Entity<Instructor>(i =>
            {
                i.ToTable("instructors").HasKey("Id");
                i.Property(i => i.Id).HasColumnName("id");
                i.Property(i => i.CompanyName).HasColumnName("company_name");
            });

            modelBuilder.Entity<State>(s =>
            {
                s.ToTable("states").HasKey("Id");
                s.Property(s => s.Id).HasColumnName("id");
                s.Property(s => s.Info).HasColumnName("info");
            });

         
        }
    }
}
