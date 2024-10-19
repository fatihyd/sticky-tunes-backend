using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Models;

namespace sticky_tunes_backend.Data;

public class StickyTunesDbContext : DbContext
{
    public StickyTunesDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Artist> Artists { get; set; }
}