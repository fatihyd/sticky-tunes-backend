namespace sticky_tunes_backend.DTOs;

public class GetPostDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DatePosted { get; set; }
}