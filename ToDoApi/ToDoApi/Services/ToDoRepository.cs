using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ToDoApi.Entities;

namespace ToDoApi.Services
{
    public class ToDoRepository: IToDoRepository
    {
        private readonly ConcurrentDictionary<Guid, TodoItem> _storage = new ConcurrentDictionary<Guid, TodoItem>();

        public ICollection<TodoItem> GetAll()
        {
            return _storage.Values;
        }

        public TodoItem GetSingle(Guid id)
        {
            TodoItem item;
            return _storage.TryGetValue(id, out item) ? item : null;
        }

        public void Insert(TodoItem item)
        {
            item.Id = Guid.NewGuid();

            if (!_storage.TryAdd(item.Id, item))
            {
                throw new Exception("Item could not be inserted");
            }
        }

        public void Delete(Guid id)
        {
            TodoItem item;
            if (!_storage.TryRemove(id, out item))
            {
                throw new Exception("Item could not be removed");
            }
        }
    }
}
