using EFCore.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Domain.Repositories;

public class CursesRepository
{
    private readonly LearningDbContext _context;

    public CursesRepository(LearningDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseEntity>> Get()
    {
        return await _context.Courses.AsNoTracking().OrderBy(c => c.Title).ToListAsync();
    }

    public async Task<List<CourseEntity>> GetWithLessons()
    {
        return await _context.Courses.AsNoTracking().Include(c => c.Lessons).ToListAsync();
    }

    public async Task<CourseEntity?> GetById(Guid id)
    {
        return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
    {
        var query = _context.Courses.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(i => i.Title.Contains(title));
        }

        if (price > 0)
        {
            query = query.Where(i => i.Price > price);
        }

        return await query.ToListAsync();
    }

    public async Task<List<CourseEntity>> GetByPage(int page, int size)
    {
        return await _context.Courses
            .AsNoTracking()
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task Add(Guid id, Guid authorid, string title, string description)
    {
        await _context.Courses.AddAsync(new CourseEntity
        {
            Id = id,
            AuthorId = authorid,
            Title = title,
            Description = description
        });
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Guid authorid, string title, string description)
    {
        var courses = await _context.Courses
            .Where(i => i.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Title, title)
                .SetProperty(x => x.Description, description)
                .SetProperty(x => x.AuthorId, authorid)
            );
    }
}