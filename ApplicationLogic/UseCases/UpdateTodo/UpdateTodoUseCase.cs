using ApplicationLogic.Base.Abstractions;
using Core.Exceptions;
using Core.Model;
using Core.Repositories;

namespace ApplicationLogic.UseCases.UpdateTodo
{
    public class UpdateTodoUseCase : IUseCase<UpdateTodoRequest>
    {
        private readonly ITodoRepository todoRepository;

        public UpdateTodoUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task ExecuteAsync(UpdateTodoRequest request)
        {
            Todo? todo = await this.todoRepository.GetById(request.Id);

            if (todo == null)
            {
                throw new TodoNotFoundException();
            }
            todo.Text = request.Text;

            await this.todoRepository.Update(todo);
        }
    }
}
