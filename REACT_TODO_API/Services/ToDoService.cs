using ToDo_Data;
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

        public Task<List<ToDoItem>> getAllToDoItems(int userid)
        {
            var IncompleteToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid,false).Result);
            var CompleteToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid, true).Result);
            var AllToDoItems = IncompleteToDoItems.Result.Concat(CompleteToDoItems.Result).ToList();
            return Task.FromResult(AllToDoItems);
        }

        public Task<List<ToDoItem>> getNewToDoItems(int userid)
        {
            var IncompleteToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid, false).Result);
            return IncompleteToDoItems;
        }

        public Task<List<ToDoItem>> getCompletedToDoItems(int userid)
        {
            var ToDoItems = Task.FromResult(_toDoRepository.getToDoItems(userid, true).Result);
            return ToDoItems;
        }

        public Task<ToDoItem> addToDoItem(ToDoItem item)
        {
            var ToDoItem = Task.FromResult(_toDoRepository.createToDoItem(item).Result);
            return ToDoItem;
        }

        public async Task<bool> deleteToDoItems(int itemid, int userid)
        {
            var currentitem = await Task.FromResult(_toDoRepository.getToDoItemById(itemid).Result);
            var toDoItem = await Task.FromResult(_toDoRepository.deleteToDoItem(currentitem, userid).Result);

            return toDoItem;
        }

        public Task<bool> updateToDoItems(ToDoItem item)
        {
            var ToDoItem = Task.FromResult(_toDoRepository.updateToDoItem(item).Result);
            return ToDoItem;
        }

        public async Task<bool> completeToDoItem(int itemId, int userid)
        {
            var currentitem = await Task.FromResult(_toDoRepository.getToDoItemById(itemId).Result);
            var ToDoItem = await Task.FromResult(_toDoRepository.completeToDoItem(currentitem).Result);
            return ToDoItem;
        }
    }
}    