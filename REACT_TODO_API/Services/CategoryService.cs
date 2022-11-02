using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using ToDo_Data;
using ToDo_Data.Interfaces;

namespace REACT_TODO_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;


        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public Task<List<CategoryId>> getCategories()
        {
            var CategoryIds = Task.FromResult(_categoriesRepository.getCategories().Result);
            return CategoryIds;
        }

        public Task<CategoryId> createCategory(CategoryId categoryId)
        {
            var category = _categoriesRepository.createCategory(categoryId);
            return category;
        }

        public Task<bool> updateCategory(CategoryId categoryId)
        {
            var categoryIds = Task.FromResult(_categoriesRepository.updateCategory(categoryId).Result);
            return categoryIds;
        }

        public Task<bool> deleteCategory(CategoryId categoryId)
        {
            var categories = _categoriesRepository.deleteCategory(categoryId);
            return categories;
        }
    }
}
