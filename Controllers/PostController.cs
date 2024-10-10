using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Data;
using sticky_tunes_backend.DTOs;
using sticky_tunes_backend.Models;
using sticky_tunes_backend.Services;

namespace sticky_tunes_backend.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly DataContext _context;
    private readonly SpotifyService _spotifyService;
    private readonly IMapper _mapper;

    public PostController(DataContext context, SpotifyService spotifyService, IMapper mapper)
    {
        _context = context;
        _spotifyService = spotifyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.Track)
            .ToListAsync();
        
        var getPostDtos = _mapper.Map<List<GetPostDto>>(posts);
        
        return Ok(getPostDtos);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var post = await _context.Posts
            .Include(p => p.Track)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (post == null)
            return NotFound();
        
        var getPostDto = _mapper.Map<GetPostDto>(post);
        
        return Ok(getPostDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
    {
        var trackId = _spotifyService.ExtractTrackId(createPostDto.SpotifyUrl);
        if (trackId == string.Empty)
        {
            return BadRequest("Invalid Spotify Url!");
        }
        
        var track = await _spotifyService.GetTrackAsync(trackId);
        _context.Tracks.Add(track);

        var post = new Post
        {
            Track = track,
            Text = createPostDto.Text,
            DatePosted = DateTime.Now
        };
        _context.Posts.Add(post);
        
        await _context.SaveChangesAsync();
        
        var getPostDto = _mapper.Map<GetPostDto>(post);
        
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id}, getPostDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeletePost([FromRoute] int id)
    {
        var post = await _context.Posts.FindAsync(id);
        
        if (post == null)
            return NotFound();
        
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}