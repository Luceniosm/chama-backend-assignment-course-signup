using CourseSignUp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSignUp.Infra.Data.Mappings
{
    public class CourseMap: IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.Description).HasColumnName("Description").HasColumnType("varchar(300)").IsRequired();
            builder.Property(m => m.Capacity).HasColumnName("Capacity").HasColumnType("int").IsRequired();
        }
    }
}
