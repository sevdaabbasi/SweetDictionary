using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;


namespace SweetDictionary.Service.Rules
{
    public class CommentBusinessRules
    {
        private readonly ICommentRepository _commentRepository;

        public CommentBusinessRules(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void CommentIsPresent(Guid commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            if (comment == null)
                throw new BusinessException("Comment not found.");
        }
    }
}