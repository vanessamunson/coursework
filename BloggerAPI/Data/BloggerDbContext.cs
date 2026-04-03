using BloggerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggerAPI.Data
{
    public class BloggerDbContext : DbContext
    {
        public BloggerDbContext(DbContextOptions<BloggerDbContext> options): base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
