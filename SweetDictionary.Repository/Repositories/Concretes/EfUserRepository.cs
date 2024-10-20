using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Models.Entities;
using Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SweetDictionary.Repository.Repositories.Concretes
{
    public class EfUserRepository : EfRepositoryBase<BaseDbContext, User, long>, IUserRepository
    {
        public EfUserRepository(BaseDbContext context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            return Context.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAllByUsernameContains(string text)
        {
            return Context.Users.Where(u => u.Username.Contains(text)).ToList();
        }
    }
}
