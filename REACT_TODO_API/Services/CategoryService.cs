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

        public Task<CategoryId> createCategory(string categoryValue)
        {
            var category = _categoriesRepository.createCategory(categoryValue);
            return category;
        }

        public async Task<bool> updateCategory(int categoryId, string categoryValue)
        {
            var currentvalue = await Task.FromResult(_categoriesRepository.getCategoryById(categoryId).Result);
            var categoryIds = await Task.FromResult(_categoriesRepository.updateCategory(currentvalue,categoryValue).Result);
            return categoryIds;
        }

        public async Task<bool> deleteCategory(int categoryId)
        {
            var currentvalue = await Task.FromResult(_categoriesRepository.getCategoryById(categoryId).Result);
            var categories = await _categoriesRepository.deleteCategory(currentvalue);
            return categories;
        }
        
        public async Task<CategoryId> GetCategoryByID(int categoryID)
        {
            var categories = await _categoriesRepository.getCategoryById(categoryID);
            return categories;

        }
    }
}
