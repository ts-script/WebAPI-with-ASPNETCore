using System;

namespace ToDoApi.Dtos
{
    public class TodoCreateDto
    {
        public string Title { get; set; }
        public string Notes { get; set; } 
        public bool Done { get; set; }
        public DateTime Created { get; set; }
    }
}
