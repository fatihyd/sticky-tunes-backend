namespace sticky_tunes_backend.DTOs;

public class CreateCommentDto
{
    public string SpotifyUrl { get; set; }
    public string? Text { get; set; }
}