using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace geekible.todo.repositories
{
    internal class ConfigureDbContext
    {
        internal static ApplicationDbContext Context
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var context = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(config.GetConnectionString("DefaultConnection"));
                return new ApplicationDbContext(context.Options);
            }
        }
    }
}
