using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Service.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CategoryIsPresent(int categoryId)
        {
            var category = _categoryRepository.GetById(categoryId);
            if (category == null)
                throw new BusinessException("Category not found.");
        }

        public void CategoryNameIsUnique(string name)
        {
            var category = _categoryRepository.GetByName(name);
            if (category != null)
                throw new BusinessException("Category name already exists.");
        }
    }
}