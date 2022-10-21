using ORMDemo.API.Infrastructure.Entities;

namespace ORMDemo.API.Infrastructure.Contexts;

public class DemoContext : DbContext
{
    public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().ToTable("blogs");
        modelBuilder.Entity<Post>().ToTable("posts");
    }
}
