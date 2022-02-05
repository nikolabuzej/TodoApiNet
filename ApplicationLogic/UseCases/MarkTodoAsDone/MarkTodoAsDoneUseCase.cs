using ApplicationLogic.Base.Abstractions;
using Core.Exceptions;
using Core.Model;
using Core.Repositories;

namespace ApplicationLogic.UseCases.MarkTodoAsDone
{
    public class MarkTodoAsDoneUseCase : IUseCase<MarkTodoAsDoneRequest>
    {
        private readonly ITodoRepository todoRepository;

        public MarkTodoAsDoneUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task ExecuteAsync(MarkTodoAsDoneRequest request)
        {
            Todo? todo = await this.todoRepository.GetById(request.Id);

            if (todo == null)
            {
                throw new TodoNotFoundException();
            }

            todo.MarkAsDone();

            await this.todoRepository.Update(todo);
        }
    }
}
