namespace sticky_tunes_backend.Models;

public class Track
{
    public int Id { get; set; }
    public string SpotifyUrl { get; set; }
    public string Name { get; set; }
    public List<string> ArtistNames { get; set; } = new List<string>();
    public string AlbumName { get; set; }
}