using Hahn.ApplicatonProcess.May2020.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.DataAccess
{
    public class ApplicantContext : DbContext
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options)
        {
        }
        public DbSet<ApplicantModel> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantModel>().HasData(new ApplicantModel
            {
                ID = 1,
                Name = "Paul",
                FamilyName = "Watson",
                Address = "1 Joseph Lambo Street, Ebute Metta, Lagos",
                CountryOfOrigin = "Nigeria",
                EMailAdress = "pauloolabisi@gmail.com",
                Age = 27,
                Hired = true
            });

            modelBuilder.Entity<ApplicantModel>().HasData(new ApplicantModel
            {
                ID = 2,
                Name = "John",
                FamilyName = "Doe",
                Address = "16, Hartfield Avenue, Banana Island, Lagos",
                CountryOfOrigin = "Nigeria",
                EMailAdress = "john.doe@outlook.com",
                Age = 22,
                Hired = false
            });
        }
    }
}
