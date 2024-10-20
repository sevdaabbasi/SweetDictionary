using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Categories;

namespace SweetDictionary.Service.Abstract;

public interface ICategoryService
{
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto);
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryResponseDto> GetByName(string name);
    ReturnModel<string> Delete(int id);
}

