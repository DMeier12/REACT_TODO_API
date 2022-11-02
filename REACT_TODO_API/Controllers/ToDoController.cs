using Microsoft.AspNetCore.Mvc;
using REACT_TODO_API.Services;
using ToDo_Data;

namespace REACT_TODO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet("GetAllTodoItems")]
        public async Task<List<ToDoItem>> getAllTodoItemsAsync(int userId)
        {
            try
            {
                var returnvalue = await _toDoService.getAllToDoItems(userId);
                return (returnvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetNewTodoItems")]
        public async Task<List<ToDoItem>> getNewTodoItemsAsync(int userId)
        {
            try
            {
                var returnvalue = await _toDoService.getNewToDoItems(userId);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetCompletedTodoItems")]
        public async Task<List<ToDoItem>> getCompletedTodoItemsAsync(int userId)
        {
            try
            {
                var returnvalue = await _toDoService.getCompletedToDoItems(userId);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("GetTodoItemById")]
        public async Task<List<ToDoItem>> getTodoItemByIdAsync(int userId)
        {
            try
            {
                var returnvalue = await _toDoService.getCompletedToDoItems(userId);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("CreateNewTodoItem")]
        public async Task<ToDoItem> CreateNewTodoItemAsync(int categoryID, string todoText, DateTime dueDate, int userId)
        {
            try
            {
                var newitem = new ToDoItem()
                {
                    CategoryId = categoryID,
                    ToDoItem1 = todoText,
                    DueDate = dueDate,
                    UserId = userId
                };
                var returnvalue = await _toDoService.addToDoItem(newitem);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("UpdateTodoItem")]
        public async Task<bool> updateTodoItemAsync(int todoItemId,int categoryId, string todoText, DateTime dueDate, int userId)
        {
            try
            {
                var newitem = new ToDoItem()
                {
                    ToDoItemId = todoItemId,
                    CategoryId = categoryId,
                    ToDoItem1 = todoText,
                    DueDate = dueDate,
                    UserId = userId
                };
                var returnvalue = await _toDoService.updateToDoItems(newitem);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("CompleteTodoItem")]
        public async Task<bool> CompleteTodoItemAsync(int todoItemId, int userId)
        {
            try
            {
                var returnvalue = await _toDoService.completeToDoItem(todoItemId,userId);
                return returnvalue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("DeleteTodoItem")]
        public async Task<bool> DeleteTodoItemAsync(int TodoItemID, int userId)
        {
            try
            {
                var returnvalue = await _toDoService.deleteToDoItems(TodoItemID,userId);
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
