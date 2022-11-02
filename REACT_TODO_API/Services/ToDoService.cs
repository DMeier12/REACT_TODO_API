using ToDo_Data;
using ToDo_Data.Repositories;
using ToDo_Data.Interfaces;

namespace REACT_TODO_API.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public Task<List<ToDoItem>> getToDoItems(int userid)
        {
            var ToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid).Result);
            return ToDoItems;
        }

        public Task<List<ToDoItem>> getCompletedToDoItems(int userid)
        {
            var ToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid, true).Result);
            return ToDoItems;
        }

        public Task<ToDoItem> addToDoItems(ToDoItem item)
        {
            var ToDoItem = Task.FromResult(_toDoRepository.createToDoItem(item).Result);
            return ToDoItem;
        }

        public Task<bool> deleteToDoItems(ToDoItem item)
        {
            var ToDoItem = Task.FromResult(_toDoRepository.deleteToDoItem(item).Result);
            return ToDoItem;
        }

        public Task<bool> updateToDoItems(ToDoItem item)
        {
            var ToDoItem = Task.FromResult(_toDoRepository.updateToDoItem(item).Result);
            return ToDoItem;
        }

    }
}    