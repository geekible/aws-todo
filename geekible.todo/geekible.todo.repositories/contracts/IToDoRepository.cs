using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using geekible.todo.models;

namespace geekible.todo.repositories.contracts
{
    public interface IToDoRepository
    {
        Task<ToDo> Create(ToDo toDo);
    }
}
