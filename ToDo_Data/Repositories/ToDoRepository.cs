using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ReactAPIContext _reactApiContext;
        public ToDoRepository(ReactAPIContext reactAPIContext)
        {
            _reactApiContext = reactAPIContext;
        }
        
        /// <summary>
        /// Returns a collection of todo items that are not completed
        /// </summary>
        /// <returns> list<ToDoItem></ToDoItem></returns>
        public async Task<List<ToDoItem>> getToDoItems(int userid,bool iscompleted = false) {
            try
            {
                var todoitems = (from item in _reactApiContext.ToDoItems
                                 where item.DateCompleted.HasValue == iscompleted
                                 where item.UserId == userid
                                 select item).ToList();
                return !todoitems.Any() ? new List<ToDoItem>() : todoitems;
            }
            catch (Exception ex)
            {
                return new List<ToDoItem>();
                throw;
            }

        }

        public async Task<ToDoItem> createToDoItem(ToDoItem item)
        {
            var todoitem = _reactApiContext.ToDoItems.Add(item).Entity;
                _reactApiContext.SaveChanges();
                return todoitem;
        }

        public async Task<bool> deleteToDoItem(ToDoItem item, int userid)
        {
            var todoitem = _reactApiContext.ToDoItems.Remove(item).Entity;
                _reactApiContext.SaveChanges();
                return true;
        }

        public async Task<bool> updateToDoItem(ToDoItem item)
        {
            var existingitem = await getToDoItemById(item.ToDoItemId);
            if (existingitem.DateCompleted != null) throw new Exception("Cannot update completed task");

            var todoitem = _reactApiContext.ToDoItems.Update(item).Entity;
            _reactApiContext.SaveChanges();
            return true;
        }
        public async Task<bool> completeToDoItem(ToDoItem item)
        {

           item.DateCompleted = DateTime.Now;
           var todoitem = _reactApiContext.ToDoItems.Update(item).Entity;
            _reactApiContext.SaveChanges();
            return true;
        }

        public async Task<ToDoItem> getToDoItemById(int toDoItemId)
        {
            var todoitem = (from item in _reactApiContext.ToDoItems
                    where item.ToDoItemId == toDoItemId
                    select item).Single();

                if (todoitem == null)
                {
                    throw new Exception("Item Not Found");
                }

                return todoitem;
            }
    }
}
