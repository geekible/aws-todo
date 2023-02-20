using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace geekible.todo.repositories
{
    public class BaseSQL<T> where T : class
    {
        private ApplicationDbContext ctx;

        public BaseSQL()
        {
            ctx = ConfigureDbContext.Context;
        }

        public void Dispose()
        {
            try
            {
                GC.Collect();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            var dbSet = ctx.Set<T>();
            var result = await dbSet.ToListAsync();
            dbSet = null;
            return result;
        }


    }
}
