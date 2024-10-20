using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Categories;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto)
    {
        Category category = _mapper.Map<Category>(dto);
        Category createdCategory = _categoryRepository.Add(category);
        var response = _mapper.Map<CategoryResponseDto>(createdCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category added.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        var responses = _mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        var response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category retrieved.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetByName(string name)
    {
        var category = _categoryRepository.GetByName(name);
        var response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category retrieved.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<string> Delete(int id)
    {
        var category = _categoryRepository.GetById(id);
        var deletedCategory = _categoryRepository.Delete(category);

        return new ReturnModel<string>
        {
            Data = deletedCategory.Name,
            Message = "Category deleted.",
            Status = 204,
            Success = true
        };
    }
}
