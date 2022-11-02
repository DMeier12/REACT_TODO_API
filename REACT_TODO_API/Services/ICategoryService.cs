using ToDo_Data;

namespace REACT_TODO_API.Services;

public interface ICategoryService
{
    Task<List<CategoryId>> getCategories();
    Task<CategoryId> createCategory(CategoryId categoryId);
    Task<bool> updateCategory(CategoryId categoryId);
    Task<bool> deleteCategory(CategoryId categoryId);
}