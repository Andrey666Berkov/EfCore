using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Domain.Configurations;

public class AuthorConfigurations:IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(a=>a.Id);
        builder.HasOne(a => a.Course)
            .WithOne(c => c.Author)
            .HasForeignKey<CourseEntity>(a => a.AuthorId);
    }
}