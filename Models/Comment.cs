using System.ComponentModel.DataAnnotations.Schema;

namespace sticky_tunes_backend.Models;

public class Comment
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public DateTime DatePosted { get; set; }
    
    [ForeignKey(nameof(Track))]
    public int TrackId { get; set; }
    public Track Track { get; set; }

    [ForeignKey(nameof(Post))]
    public int PostId { get; set; }
    public Post Post { get; set; }
}