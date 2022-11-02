using Microsoft.AspNetCore.Mvc;
using REACT_TODO_API.Services;
using ToDo_Data;

namespace REACT_TODO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        } 

        [HttpGet("GetCategories")]
        public async Task<List<CategoryId>> getCategoryAsync()
        {
            try
            {
                var returnvalue = await _categoriesService.getCategories();
                return (returnvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetCategoryByID")]
        public async Task<CategoryId> getCategoryByIdAsync(int categoryid)
        {
            try
            {
                var returnvalue = await _categoriesService.GetCategoryByID(categoryid);
                return (returnvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("CreateCategory")]
        public async Task<CategoryId> createCategoryAsync(string category)
        {
            try
            {
                var returnvalue = await _categoriesService.createCategory(category);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("UpdateCategory")]
        public async Task<bool> updateCategoryAsync(int categoryid, string categoryValue)
        {
            try
            {
                var returnvalue = await _categoriesService.updateCategory(categoryid, categoryValue);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("DeleteCategory")]
        public async Task<bool> deleteCategoryAsync(int categoryid)
        {
            try
            {
                var returnvalue = await _categoriesService.deleteCategory(categoryid);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
