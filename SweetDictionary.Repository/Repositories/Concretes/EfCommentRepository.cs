using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;


namespace SweetDictionary.Repository.Repositories.Concretes
{
    public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
    {
        public EfCommentRepository(BaseDbContext context) : base(context)
        {
        }

        public List<Comment> GetAllByPostId(Guid postId)
        {
            return Context.Comments.Where(x => x.PostId == postId).ToList();
        }

        public List<Comment> GetAllByUserId(long userId)
        {
            return Context.Comments.Where(x => x.UserId == userId).ToList();
        }
    }
}