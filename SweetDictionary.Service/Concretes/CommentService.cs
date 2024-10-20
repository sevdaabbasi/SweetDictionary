using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Comments;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service.Concretes;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly CommentBusinessRules _businessRules;

    public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules businessRules)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto)
    {
        Comment createdComment = _mapper.Map<Comment>(dto);
        createdComment.Id = Guid.NewGuid();

        Comment comment = _commentRepository.Add(createdComment);
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment added.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<string> Delete(Guid id)
    {
        _businessRules.CommentIsPresent(id);

        Comment comment = _commentRepository.GetById(id);
        Comment deletedComment = _commentRepository.Delete(comment);

        return new ReturnModel<string>
        {
            Data = $"Comment by User: {deletedComment.User.Username}",
            Message = "Comment deleted.",
            Status = 204,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        var comments = _commentRepository.GetAll();
        var responses = _mapper.Map<List<CommentResponseDto>>(comments);
        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId)
    {
        var comments = _commentRepository.GetAllByPostId(postId);
        var responses = _mapper.Map<List<CommentResponseDto>>(comments);
        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = $"Comments for Post ID: {postId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByUserId(long userId)
    {
        var comments = _commentRepository.GetAllByUserId(userId);
        var responses = _mapper.Map<List<CommentResponseDto>>(comments);
        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = $"Comments by User ID: {userId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        _businessRules.CommentIsPresent(id);

        Comment comment = _commentRepository.GetById(id);
        var response = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment retrieved.",
            Status = 200,
            Success = true
        };
    }
}


