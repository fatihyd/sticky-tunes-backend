using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Models;

namespace sticky_tunes_backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}