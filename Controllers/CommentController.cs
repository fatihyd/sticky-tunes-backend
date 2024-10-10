using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sticky_tunes_backend.Data;
using sticky_tunes_backend.DTOs;
using sticky_tunes_backend.Models;

namespace sticky_tunes_backend.Controllers;

[ApiController]
[Route("api/posts/{postId}/comments")]
public class CommentController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CommentController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments([FromRoute] int postId)
    {
        var comments = await _context.Comments.Where(c => c.Post.Id == postId).ToListAsync();
        
        var getCommentDtos = _mapper.Map<List<GetCommentDto>>(comments);
        
        return Ok(getCommentDtos);
    }

    [HttpGet]
    [Route("{commentId}")]
    public async Task<IActionResult> GetCommentById([FromRoute] int postId, [FromRoute] int commentId)
    {
        var comment = await _context.Comments
            .Where(c => c.Id == commentId && c.Post.Id == postId)
            .SingleOrDefaultAsync();
        
        if (comment == null)
            return NotFound();
        
        var getCommentDto = _mapper.Map<GetCommentDto>(comment);
        
        return Ok(getCommentDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromRoute] int postId, [FromBody] CreateCommentDto createCommentDto)
    {
        var comment = _mapper.Map<Comment>(createCommentDto);
        comment.DatePosted = DateTime.Now;
        comment.Post = await _context.Posts.FindAsync(postId);
        
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var getCommentDto = _mapper.Map<GetCommentDto>(comment);
        
        return CreatedAtAction(nameof(GetCommentById), new { postId = postId, id = comment.Id}, getCommentDto);
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