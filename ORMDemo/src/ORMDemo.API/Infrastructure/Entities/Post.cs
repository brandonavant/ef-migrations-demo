namespace ORMDemo.API.Infrastructure.Entities;

public class Post
{
    public Guid PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    // Navigation Properties

    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }
}
