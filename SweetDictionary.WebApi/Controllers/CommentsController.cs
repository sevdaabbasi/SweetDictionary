using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Comments;
using SweetDictionary.Service.Abstract;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCommentRequestDto dto)
    {
        var result = _commentService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpGet("getbypostid/{postId}")]
    public IActionResult GetAllByPostId([FromRoute] Guid postId)
    {
        var result = _commentService.GetAllByPostId(postId);
        return Ok(result);
    }

    [HttpGet("getbyuserid/{userId}")]
    public IActionResult GetAllByUserId([FromRoute] long userId)
    {
        var result = _commentService.GetAllByUserId(userId);
        return Ok(result);
    }
}