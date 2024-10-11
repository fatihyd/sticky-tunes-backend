namespace sticky_tunes_backend.Models;

public class Comment
{
    public int Id { get; set; }
    public Track Track { get; set; }
    public string? Text { get; set; }
    public DateTime DatePosted { get; set; }
    public Post Post { get; set; }
}