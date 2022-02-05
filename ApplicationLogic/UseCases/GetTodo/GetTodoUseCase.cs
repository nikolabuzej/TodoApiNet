using ApplicationLogic.Base.Abstractions;
using Core.Model;
using Core.Repositories;

namespace ApplicationLogic.UseCases.GetTodo
{
    public class GetTodoUseCase : IUseCase<GetTodoRequest, GetTodoResponse>
    {
        private readonly ITodoRepository todoRepository;

        public GetTodoUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<GetTodoResponse> ExecuteAsync(GetTodoRequest request)
        {
            Todo? todo = await this.todoRepository.GetById(request.Id);

            return new(todo);
        }
    }
}
