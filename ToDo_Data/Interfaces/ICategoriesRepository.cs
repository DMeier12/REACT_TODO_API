namespace ToDo_Data.Interfaces;

public interface ICategoriesRepository
{
    Task<List<CategoryId>> getCategories();
    Task<CategoryId> createCategory(CategoryId categoryId);
    Task<bool> deleteCategory(CategoryId categoryId);
    Task<bool> updateCategory(CategoryId categoryId);
}