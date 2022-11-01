namespace ToDo_Data.Interfaces;

public interface IToDoRepository
{
    /// <summary>
    /// Returns a collection of todo items that are not completed
    /// </summary>
    /// <returns> list<ToDoItem></ToDoItem></returns>
    Task<List<ToDoItem>> getToDoItems(int userid,bool iscompleted = false);

    Task<ToDoItem> createToDoItem(ToDoItem item);
    Task<bool> deleteToDoItem(ToDoItem item);
    Task<bool> updateToDoItem(ToDoItem item);
    Task<bool> completeToDoItem(ToDoItem item);
}