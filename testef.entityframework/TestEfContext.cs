using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using testef.models;

namespace testef.entityframework
{
    public class TestEfContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }

        //configure connection to localDb
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=efTest;trusted_connection=true;");
        
        //configure table names that are not plural
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Education>().ToTable("Education");

            //configure reletionship
            modelBuilder.Entity<PersonEducation>()
                .HasKey(pe => new { pe.PersonId, pe.EducationId });
            modelBuilder.Entity<PersonEducation>()
                .HasOne(pe => pe.Person)
                .WithMany(p => p.PersonEducations)
                .HasForeignKey(pe => pe.PersonId);
            modelBuilder.Entity<PersonEducation>()
                .HasOne(pe => pe.Education)
                .WithMany(e => e.PersonEducations)
                .HasForeignKey(pe => pe.EducationId);

            //seed data Person
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Harry Stals",
                PostalCode = "6371XX",
                City = "Maastricht",
                CitizenServiceNumber = 111222333,
                Email = "HStals@ilionx.com",
                BusinessPhoneNumber = "0612345678"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Linda Curvers",
                PostalCode = "6371XX",
                City = "Maastricht",
                CitizenServiceNumber = 111222333,
                Email = "LCurvers@ilionx.com",
                BusinessPhoneNumber = "0612345678"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Denny van Horst",
                PostalCode = "6371XX",
                City = "Maastricht",
                CitizenServiceNumber = 111222333,
                Email = "DVanHorst@ilionx.com",
                BusinessPhoneNumber = "0612345678"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Kyra Hansen",
                PostalCode = "6371XX",
                City = "Maastricht",
                CitizenServiceNumber = 111222333,
                Email = "KHansen@ilionx.com",
                BusinessPhoneNumber = "0612345678"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = Guid.NewGuid(),
                Name = "Guus Jansen",
                PostalCode = "6371XX",
                City = "Maastricht",
                CitizenServiceNumber = 111222333,
                Email = "GJansen@ilionx.com",
                BusinessPhoneNumber = "0612345678"
            });

            //seed data Education

            modelBuilder.Entity<Education>().HasData(new Education
            {
                EducationId = Guid.NewGuid(),
                EducationalInstitute = "Fontys Venlo University of Applied Sciences",
                Course = "Software Engineering",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2024-01-01"),
                Category = "IT",
                Level = "HBO"
            });
            modelBuilder.Entity<Education>().HasData(new Education
            {
                EducationId = Guid.NewGuid(),
                EducationalInstitute = "Fontys Venlo University of Applied Sciences",
                Course = "Business Informatics",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2024-01-01"),
                Category = "IT",
                Level = "HBO"
            });
            modelBuilder.Entity<Education>().HasData(new Education
            {
                EducationId = Guid.NewGuid(),
                EducationalInstitute = "Zuyd Hogeschool University of Applied Sciences",
                Course = "Software Engineering",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2024-01-01"),
                Category = "IT",
                Level = "HBO"
            });
            modelBuilder.Entity<Education>().HasData(new Education
            {
                EducationId = Guid.NewGuid(),
                EducationalInstitute = "Fontys Eindhoven University of Applied Sciences",
                Course = "Software Engineering",
                StartDate = DateTime.Parse("2020-01-01"),
                EndDate = DateTime.Parse("2024-01-01"),
                Category = "IT",
                Level = "HBO"
            });
        }
    }
}
