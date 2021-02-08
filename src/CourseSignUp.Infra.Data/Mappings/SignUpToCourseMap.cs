using CourseSignUp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSignUp.Infra.Data.Mappings
{
    public class SignUpToCourseMap: IEntityTypeConfiguration<SignUpToCourse>
    {
        public void Configure(EntityTypeBuilder<SignUpToCourse> builder)
        {
            builder.ToTable("SignUpToCourse", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.IdCourse).HasColumnName("IdCourse").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.IdStudent).HasColumnName("IdStudent").HasColumnType("uniqueidentifier").IsRequired();

            builder
                .HasOne(m => m.Course)
                .WithMany()
                .HasForeignKey(m => m.IdCourse);

            builder
                .HasOne(m => m.Student)
                .WithOne()
                .HasForeignKey<SignUpToCourse>(e => e.IdStudent);
        }
    }
}
