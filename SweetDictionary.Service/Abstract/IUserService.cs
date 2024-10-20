using SweetDictionary.Models.Users;
using Core.Entities;

namespace SweetDictionary.Service.Abstract
{
    public interface IUserService
    {
        ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto);
        ReturnModel<UserResponseDto> Update(UpdateUserRequestDto dto);
        ReturnModel<string> Delete(long id);
        ReturnModel<UserResponseDto> GetById(long id);
        ReturnModel<List<UserResponseDto>> GetAll();
        ReturnModel<UserResponseDto> GetByEmail(string email);
        ReturnModel<List<UserResponseDto>> GetAllByUsernameContains(string text);
    }
}