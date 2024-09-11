using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Domain.Configurations;

public class LessonsConfigurations:IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.HasKey(l=>l.Id);
        builder.HasOne(a => a.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l=>l.CourseId);

    }
}