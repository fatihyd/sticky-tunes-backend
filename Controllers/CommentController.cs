using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Data;
using sticky_tunes_backend.DTOs;
using sticky_tunes_backend.Models;
using sticky_tunes_backend.Services;

namespace sticky_tunes_backend.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
public class CommentController : ControllerBase
{
    private readonly StickyTunesDbContext _context;
    private readonly SpotifyService _spotifyService;
    private readonly IMapper _mapper;

    public CommentController(StickyTunesDbContext context, SpotifyService spotifyService, IMapper mapper)
    {
        _context = context;
        _spotifyService = spotifyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments([FromRoute] int postId)
    {
        var comments = await _context.Comments
            .Where(c => c.Post.Id == postId)
            .Include(c => c.Track)
            .ToListAsync();
        
        var getCommentDtos = _mapper.Map<List<GetCommentDto>>(comments);
        
        return Ok(getCommentDtos);
    }

    [HttpGet]
    [Route("{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] int postId, [FromRoute] int commentId)
    {
        var comment = await _context.Comments
            .Where(c => c.Id == commentId && c.Post.Id == postId)
            .Include(p => p.Track)
            .FirstOrDefaultAsync();
        
        if (comment == null)
            return NotFound();
        
        var getCommentDto = _mapper.Map<GetCommentDto>(comment);
        
        return Ok(getCommentDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromRoute] int postId, [FromBody] CreateCommentDto createCommentDto)
    {
        var track = await _spotifyService.GetTrackAsync(createCommentDto.SpotifyUrl);
        _context.Tracks.Add(track);

        var comment = new Comment
        {
            Track = track,
            Text = createCommentDto.Text,
            DatePosted = DateTime.Now,
            Post = await _context.Posts.FindAsync(postId)
        };
        _context.Comments.Add(comment);
        
        await _context.SaveChangesAsync();
        
        var getCommentDto = _mapper.Map<GetCommentDto>(comment);
        
        return CreatedAtAction(nameof(GetCommentById), new { postId = postId, commentId = comment.Id}, getCommentDto);
    }

    [HttpDelete]
    [Route("{commentId}")]
    public async Task<IActionResult> DeleteComment([FromRoute] int postId, [FromRoute] int commentId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        
        if (comment == null)
            return NotFound();
        
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}