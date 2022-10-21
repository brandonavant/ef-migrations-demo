namespace ORMDemo.API.Infrastructure.Entities;

public class Blog
{
    public Guid BlogId { get; set; }
    public DateTime CreatedTimestamp { get; set; }
    public DateTime ModifiedTimestamp { get; set; }

    // Navigation Properties

    public List<Post> Posts { get; set; }
}
