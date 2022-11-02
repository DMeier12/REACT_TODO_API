using ToDo_Data;

namespace REACT_TODO_API.Services;

public interface IToDoService
{
    Task<List<ToDoItem>> getToDoItems(int userid);
    Task<List<ToDoItem>> getCompletedToDoItems(int userid);
    Task<ToDoItem> addToDoItems(ToDoItem item);
    Task<bool> deleteToDoItems(ToDoItem item);
    Task<bool> updateToDoItems(ToDoItem item);
}