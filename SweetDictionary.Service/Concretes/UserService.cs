using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Rules;
using System.Collections.Generic;

namespace SweetDictionary.Service.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _businessRules;

        public UserService(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto)
        {
            _businessRules.EmailIsUnique(dto.Email);

            User newUser = _mapper.Map<User>(dto);
            newUser.Id = 0; // Identity ile oluşturulacak
            User user = _userRepository.Add(newUser);

            UserResponseDto response = _mapper.Map<UserResponseDto>(user);
            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "User eklendi.",
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto> Update(UpdateUserRequestDto dto)
        {
            _businessRules.UserIsPresent(dto.Id);

            User user = _mapper.Map<User>(dto);
            User updatedUser = _userRepository.Update(user);

            UserResponseDto response = _mapper.Map<UserResponseDto>(updatedUser);
            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "User güncellendi.",
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<string> Delete(long id)
        {
            _businessRules.UserIsPresent(id);

            User user = _userRepository.GetById(id);
            _userRepository.Delete(user);

            return new ReturnModel<string>
            {
                Data = $"User Deleted: {user.Username}",
                Message = "User silindi.",
                Status = 204,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto> GetById(long id)
        {
            _businessRules.UserIsPresent(id);

            User user = _userRepository.GetById(id);
            UserResponseDto response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "User getirildi.",
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<UserResponseDto> GetByEmail(string email)
        {
            User user = _userRepository.GetByEmail(email);
            UserResponseDto response = _mapper.Map<UserResponseDto>(user);

            return new ReturnModel<UserResponseDto>
            {
                Data = response,
                Message = "User getirildi.",
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<List<UserResponseDto>> GetAll()
        {
            var users = _userRepository.GetAll();
            List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);
            return new ReturnModel<List<UserResponseDto>>
            {
                Data = responses,
                Message = "Users listelendi.",
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<List<UserResponseDto>> GetAllByUsernameContains(string text)
        {
            var users = _userRepository.GetAllByUsernameContains(text);
            var responses = _mapper.Map<List<UserResponseDto>>(users);
            return new ReturnModel<List<UserResponseDto>>
            {
                Data = responses,
                Message = $"Users listelendi. Kullanıcı adında '{text}' içerenler.",
                Status = 200,
                Success = true
            };
        }
    }
}
