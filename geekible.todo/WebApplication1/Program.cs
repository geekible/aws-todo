using geekible.todo.logic;
using geekible.todo.logic.contracts;
using geekible.todo.repositories;
using geekible.todo.repositories.contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
//logic
builder.Services.AddScoped<IBuildEnvironment, BuildEnvironment>();
builder.Services.AddScoped<IToDoLogic, ToDoLogic>();

//repositories
builder.Services.AddScoped<IDynamoDBTableMigrations, DynamoDBTableMigrations>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
//End DI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
