using ToDo_Data;

namespace REACT_TODO_API.Services;

public interface ICategoryService
{
    Task<List<CategoryId>> getCategories();
    Task<CategoryId> createCategory(string categoryId);
    Task<bool> updateCategory(int categoryId, string CategoryValue);
    Task<bool> deleteCategory(int categoryId);
    Task<CategoryId> GetCategoryByID(int CategoryID);
}