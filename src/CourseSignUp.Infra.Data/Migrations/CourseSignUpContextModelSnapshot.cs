﻿// <auto-generated />
using System;
using CourseSignUp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseSignUp.Infra.Data.Migrations
{
    [DbContext(typeof(CourseSignUpContext))]
    partial class CourseSignUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CourseSignUp.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Description");

                    b.HasKey("Id");

                    b.ToTable("Course", "dbo");
                });

            modelBuilder.Entity("CourseSignUp.Domain.Models.SignUpToCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("IdCourse")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdCourse");

                    b.Property<Guid>("IdStudent")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdStudent");

                    b.HasKey("Id");

                    b.HasIndex("IdCourse");

                    b.HasIndex("IdStudent")
                        .IsUnique();

                    b.ToTable("SignUpToCourse", "dbo");
                });

            modelBuilder.Entity("CourseSignUp.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Student", "dbo");
                });

            modelBuilder.Entity("CourseSignUp.Domain.Models.SignUpToCourse", b =>
                {
                    b.HasOne("CourseSignUp.Domain.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("IdCourse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseSignUp.Domain.Models.Student", "Student")
                        .WithOne()
                        .HasForeignKey("CourseSignUp.Domain.Models.SignUpToCourse", "IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
