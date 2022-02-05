using ApplicationLogic.Base.Abstractions;
using ApplicationLogic.UseCases.CreateTodo;
using ApplicationLogic.UseCases.GetTodo;
using ApplicationLogic.UseCases.GetTodos;
using Core.Repositories;
using Infrastructure.Repositores.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("TodoMongoDatabase"));
builder.Services.AddTransient<ITodoRepository, TodoRepositoryMongo>();
builder.Services.AddTransient<IUseCase<CreateTodoRequest>, CreateTodoUseCase>();
builder.Services.AddTransient<IUseCase<GetTodosRequest, GetTodosResponse>, GetTodosUseCase>();
builder.Services.AddTransient<IUseCase<GetTodoRequest, GetTodoResponse>, GetTodoUseCase>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
