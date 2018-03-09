using System;
namespace ToDoApi.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        public DateTime Created { get; set; }
    }
}
