using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ReactAPIContext _reactApiContext;
        public CategoriesRepository(ReactAPIContext reactApiContext)
        {
            _reactApiContext = reactApiContext;
        }

        public async Task<List<CategoryId>> getCategories()
        {
            try
            {
                var categories = (from item in _reactApiContext.CategoryIds
                                  select item).ToList();
                return categories;
            }
            catch (Exception)
            {
                return new List<CategoryId>();
                throw;
            }
        }

        public async Task<CategoryId> createCategory(string categoryValue)
        {
            var newCategory = new CategoryId()
            {
                Category = categoryValue
            };
            var categoryId = _reactApiContext.CategoryIds.AddAsync(newCategory).Result.Entity;
            _reactApiContext.SaveChanges();
            return categoryId;
        }

        public async Task<bool> deleteCategory(CategoryId categoryId)
        {
            try
            {
                var categoryid = _reactApiContext.CategoryIds.Remove(categoryId).Entity;
                _reactApiContext.SaveChanges();
                return true;
            } 
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> updateCategory(CategoryId categoryId, string categoryValue)
        {
            categoryId.Category = categoryValue;
            var categoryid = _reactApiContext.CategoryIds.Update(categoryId).Entity;
            _reactApiContext.SaveChanges();
            return true;

        }

        public async Task<CategoryId> getCategoryById(int categoryId)
        {
            var category = (from item in _reactApiContext.CategoryIds
                              where item.CategoryId1 == categoryId select item).Single();
            return category;
        }

    }
}
