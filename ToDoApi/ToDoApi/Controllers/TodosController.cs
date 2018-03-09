using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Dtos;
using ToDoApi.Entities;
using ToDoApi.Services;


using ToDoApi.Dtos;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodosController: Controller
    {
        private readonly IToDoRepository _toDoRepository;
        
        public TodosController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpGet]
        public IActionResult GetTodos()
        {
            ICollection<TodoItem> todoItemsList = _toDoRepository.GetAll().ToList();

            IEnumerable<TodoDto> viewModels = todoItemsList
                .Select(x => Mapper.Map<TodoDto>(x));
            
            return Ok(viewModels);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTodoById(Guid id)
        {
            TodoItem item = _toDoRepository.GetSingle(id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<TodoDto>(item));
        }

        [HttpPost]
        public IActionResult AddTodo([FromBody] TodoCreateDto viewModel)
        {
            if (viewModel == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TodoItem addItem = Mapper.Map<TodoItem>(viewModel);
            
            _toDoRepository.Insert(addItem);
            
            TodoItem newItem = _toDoRepository.GetSingle(addItem.Id);

            return CreatedAtRoute("GetTodoById", new {id = newItem.Id}, Mapper.Map<TodoDto>(newItem));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveTodo(Guid id)
        {
            TodoItem item = _toDoRepository.GetSingle(id);

            if (item == null)
                return NotFound();
            
            _toDoRepository.Delete(id);

            return NoContent();
        }
    }
}
