using Entities;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class BloggerDbContext : DbContext
{
    public BloggerDbContext(DbContextOptions<BloggerDbContext> options): base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
}
