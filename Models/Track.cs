namespace sticky_tunes_backend.Models;

public class Track
{
    public int Id { get; set; }
    public string SpotifyTrackId { get; set; }
    public string Name { get; set; }
    public List<Artist> Artists { get; set; } = new List<Artist>();
    public string AlbumName { get; set; }
}