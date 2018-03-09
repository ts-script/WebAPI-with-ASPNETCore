using System;
using System.Collections.Generic;
using ToDoApi.Entities;

namespace ToDoApi.Services
{
    public interface IToDoRepository
    {
        ICollection<TodoItem> GetAll();
        TodoItem GetSingle(Guid id);
        void Insert(TodoItem item);
        void Delete(Guid id);
    }
}
