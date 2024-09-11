namespace EFCore.Domain.Model;

public class AuthorEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    public CourseEntity? Course  { get; set; }
    public Guid CourseId { get; set; }
    
}