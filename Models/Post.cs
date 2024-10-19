using System.ComponentModel.DataAnnotations.Schema;

namespace sticky_tunes_backend.Models;

public class Post
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DatePosted { get; set; }
    
    [ForeignKey(nameof(Track))]
    public int TrackId { get; set; }
    public Track Track { get; set; }
    
    public List<Comment> Comments { get; set; } = new List<Comment>();
}