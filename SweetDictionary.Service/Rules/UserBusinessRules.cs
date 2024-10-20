using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;


namespace SweetDictionary.Service.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserIsPresent(long userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                throw new BusinessException("User not found.");
        }

        public void EmailIsUnique(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user != null)
                throw new BusinessException("Email already exists.");
        }
    }
}