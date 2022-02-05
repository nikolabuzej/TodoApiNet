using ApplicationLogic.Base.Abstractions;
using Core.Exceptions;
using Core.Model;
using Core.Repositories;

namespace ApplicationLogic.UseCases.DeleteTodo
{
    public class DeleteTodoUseCase : IUseCase<DeleteTodoRequest>
    {
        private readonly ITodoRepository todoRepository;

        public DeleteTodoUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task ExecuteAsync(DeleteTodoRequest request)
        {
            Todo todo = await this.todoRepository.GetById(request.Id);

            if (todo == null)
            {
                throw new TodoNotFoundException();
            }

            await this.todoRepository.Delete(todo);
        }
    }
}
