using ApplicationLogic.Base.Abstractions;
using Core.Model;
using Core.Repositories;

namespace ApplicationLogic.UseCases.CreateTodo
{
    public class CreateTodoUseCase : IUseCase<CreateTodoRequest>
    {
        private readonly ITodoRepository todoRepository;

        public CreateTodoUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public Task ExecuteAsync(CreateTodoRequest request)
        {
            Todo todo = new(request.Text);

            return this.todoRepository.Insert(todo);
        }
    }
}
