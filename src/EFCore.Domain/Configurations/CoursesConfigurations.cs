using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Domain.Configurations;

public class CoursesConfigurations:IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(c => c.CourseId);
        
        builder.HasMany(c=>c.Students)
            .WithMany(s=>s.Courses);
        
        builder.HasOne(a=>a.Author)
            .WithOne(c=>c.Course)
            .HasForeignKey<AuthorEntity>(c=>c.CourseId);

    }
}