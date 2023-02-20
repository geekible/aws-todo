using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.repositories
{
    public class BaseSQL<T> where T : class
    {
        private ApplicationDbContext ctx;

        public BaseSQL()
        {
            ctx =         
        }
    }
}
