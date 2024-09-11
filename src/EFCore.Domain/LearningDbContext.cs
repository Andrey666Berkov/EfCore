using EFCore.Domain.Configurations;
using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain;

public class LearningDbContext(DbContextOptions<LearningDbContext> options) : DbContext(options)
{
    
    public DbSet<LessonEntity> Lessons { get; set; } = default!;
    public DbSet<CourseEntity> Courses { get; set; } = default!;
    public DbSet<AuthorEntity> Authors { get; set; } = default!;
    public DbSet<StudentEntity> Stidents { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CoursesConfigurations());
        modelBuilder.ApplyConfiguration(new AuthorConfigurations());
        modelBuilder.ApplyConfiguration(new StudentsConfigurations());
        modelBuilder.ApplyConfiguration(new LessonsConfigurations());
        base.OnModelCreating(modelBuilder);
    }
}