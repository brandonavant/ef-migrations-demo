using Microsoft.AspNetCore.Mvc;

namespace ORMDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly DemoContext _demoContext;

    public BlogController(DemoContext demoContext)
    {
        _demoContext = demoContext;
    }

    [HttpGet]
    public async Task<List<Blog>> GetBlogs()
    {
        return await _demoContext.Blogs.ToListAsync();
    }

    [HttpPost]
    public async Task AddBlog(Blog blog)
    {
        await _demoContext.AddAsync<Blog>(blog);
        await _demoContext.SaveChangesAsync();
    }
}
