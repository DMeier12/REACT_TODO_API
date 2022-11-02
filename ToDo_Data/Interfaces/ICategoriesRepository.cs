namespace ToDo_Data.Interfaces;

public interface ICategoriesRepository
{
    Task<List<CategoryId>> getCategories();
    Task<CategoryId> createCategory(string categoryValue);
    Task<bool> deleteCategory(CategoryId categoryId);
    Task<bool> updateCategory(CategoryId categoryId, string categoryValue);
    Task<CategoryId> getCategoryById(int categoryId);
}