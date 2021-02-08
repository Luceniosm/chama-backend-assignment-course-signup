using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CourseSignUp.Infra.Data.Context
{
    public class CourseSignUpContext: DbContext
    {
        public CourseSignUpContext()
        {           
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<SignUpToCourse> SignUpToCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Course>(new CourseMap());
            modelBuilder.ApplyConfiguration<SignUpToCourse>(new SignUpToCourseMap());
            modelBuilder.ApplyConfiguration<Student>(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{envName}.json")
                .Build();

            // define the database to use
            optionsBuilder
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
        }
    }
}
