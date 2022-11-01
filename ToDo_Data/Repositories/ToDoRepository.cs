using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Data.Interfaces;

namespace ToDo_Data.Repositories
{
    internal class ToDoRepository : IToDoRepository
    {
        private readonly ReactAPIContext _reactAPIContext;
        public ToDoRepository(ReactAPIContext reactAPIContext)
        {
            _reactAPIContext = reactAPIContext; 
        }
        
        /// <summary>
        /// Returns a collection of todo items that are not completed
        /// </summary>
        /// <returns> list<ToDoItem></ToDoItem></returns>
        public async Task<List<ToDoItem>> getToDoItems(int userid,bool iscompleted = false) {
            try
            {
                var todoitems = (from item in _reactAPIContext.ToDoItems
                                 where item.DateCompleted.HasValue == iscompleted
                                 where item.UserId == userid
                                 select item).ToList();
                if (!todoitems.Any()) { return new List<ToDoItem>(); }
                return todoitems;
            }
            catch (Exception ex)
            {
                return new List<ToDoItem>();
                throw;
            }

        }

        public async Task<ToDoItem> createToDoItem(ToDoItem item)
        {
            try
            {
                var todoitem = _reactAPIContext.ToDoItems.AddAsync(item).Result.Entity;
                return todoitem;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> deleteToDoItem(ToDoItem item)
        {
            try
            {
                var todoitem = _reactAPIContext.ToDoItems.Remove(item).Entity;
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> updateToDoItem(ToDoItem item)
        {
            try
            {
                var todoitem = _reactAPIContext.ToDoItems.Update(item).Entity;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public async Task<bool> completeToDoItem(ToDoItem item)
        {
            try
            {
                item.DateCompleted = DateTime.Now;
                var todoitem = _reactAPIContext.ToDoItems.Update(item).Entity;
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
