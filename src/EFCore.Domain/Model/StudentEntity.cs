namespace EFCore.Domain.Model;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }=string.Empty;
    public string Description { get; set; }=string.Empty;
    public List<CourseEntity> Courses { get; set; } = [];
    
}