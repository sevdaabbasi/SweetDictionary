using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Comments;

namespace SweetDictionary.Service.Abstract;

public interface ICommentService
{
    ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto);
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId);
    ReturnModel<List<CommentResponseDto>> GetAllByUserId(long userId);
    ReturnModel<string> Delete(Guid id);
}