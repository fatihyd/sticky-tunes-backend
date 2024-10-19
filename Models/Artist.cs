namespace sticky_tunes_backend.Models;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Track> Tracks { get; set; } = new List<Track>();
}