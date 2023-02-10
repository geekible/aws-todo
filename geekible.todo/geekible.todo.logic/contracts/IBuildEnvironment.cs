using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.logic.contracts
{
    public interface IBuildEnvironment
    {
        Task Build();
    }
}
