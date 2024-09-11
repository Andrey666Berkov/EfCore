using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Domain.Configurations;

public class StudentsConfigurations:IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.HasMany(c => c.Courses)
            .WithMany(s => s.Students);
        
    }
}