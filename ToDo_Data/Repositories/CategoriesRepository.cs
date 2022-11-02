using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ReactAPIContext _reactAPIContext;
        public CategoriesRepository()
        {
            _reactAPIContext = new ReactAPIContext();
        }


        public async Task<List<CategoryId>> getCategories()
        {
            try
            {
                var categories = (from item in _reactAPIContext.CategoryIds
                                  select item).ToList();
                return categories;
            }
            catch (Exception)
            {
                return new List<CategoryId>();
                throw;
            }
        }

        public async Task<CategoryId> createCategory(CategoryId categoryId)
        {
            try
            {
                var categoryid = _reactAPIContext.CategoryIds.AddAsync(categoryId).Result.Entity;
                return categoryId;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> deleteCategory(CategoryId categoryId)
        {
            try
            {
                var categoryid = _reactAPIContext.CategoryIds.Remove(categoryId).Entity;
                return true;
            } 
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> updateCategory(CategoryId categoryId)
        {
            try
            {
                var categoryid = _reactAPIContext.CategoryIds.Update(categoryId).Entity;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
