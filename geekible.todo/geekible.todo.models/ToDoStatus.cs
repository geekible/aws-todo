using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.models
{
    public class ToDoStatus : BaseModel
    {
        public string StatusTitle { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
