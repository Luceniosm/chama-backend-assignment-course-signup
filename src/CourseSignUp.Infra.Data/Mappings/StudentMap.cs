using CourseSignUp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSignUp.Infra.Data.Mappings
{
    public class StudentMap: IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.Name).HasColumnName("Name").HasColumnType("varchar(300)").IsRequired();
            builder.Property(m => m.Email).HasColumnName("Email").HasColumnType("varchar(300)").IsRequired();
            builder.Property(m => m.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("datetime").IsRequired();
        }
    }
}
