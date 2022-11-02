using ToDo_Data;

namespace REACT_TODO_API.Services;

public interface IToDoService
{
    
    Task<ToDoItem> addToDoItem(ToDoItem item);
    Task<bool> deleteToDoItems(int item, int userid);
    Task<bool> updateToDoItems(ToDoItem item);
    Task<bool> completeToDoItem(int toDoItemId, int userid);

    Task<List<ToDoItem>> getAllToDoItems(int userid); 
    Task<List<ToDoItem>> getNewToDoItems(int userid);
    Task<List<ToDoItem>> getCompletedToDoItems(int userid);
}