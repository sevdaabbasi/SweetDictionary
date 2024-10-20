using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Repositories.Abstracts
{
    public interface IUserRepository : IRepository<User, long>
    {
        User GetByEmail(string email);
        List<User> GetAllByUsernameContains(string text);
    }
}