using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geekible.todo.logic.contracts;
using geekible.todo.models;
using geekible.todo.repositories.contracts;

namespace geekible.todo.logic
{
    public class ToDoLogic : IToDoLogic
    {
        private readonly IToDoRepository _repository;

        public ToDoLogic(IToDoRepository repo)
        {
            _repository = repo;
        }

        public async Task<ToDo> Create(ToDo toDo)
        {
            var exceptionMsg = new StringBuilder();
            toDo.ID = Guid.NewGuid().ToString();

            toDo.StartDate = toDo.StartDate.Date;
            toDo.DueDate = toDo.DueDate.Date;

            if (string.IsNullOrEmpty(toDo.AssignedToUserId) || string.IsNullOrEmpty(toDo.AssignedByUserId))
            {
                exceptionMsg.AppendLine("either assigned to or assigned by must have a user id");
            }
            
            if (string.IsNullOrEmpty(toDo.Title))
            {
                exceptionMsg.AppendLine("a title for the item must be supplied");
            }
            
            if (toDo.StartDate < DateTime.Now.Date)
            {
                exceptionMsg.AppendLine("start date cannot be in the past");
            }

            if (toDo.DueDate < toDo.StartDate)
            {
                exceptionMsg.AppendLine("due date cannot be before start date");
            }

            if (exceptionMsg.Length > 0)
            {
                throw new Exception(exceptionMsg.ToString());
            }

            return await _repository.Create(toDo);
        }
    }
}
