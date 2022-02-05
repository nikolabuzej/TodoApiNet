using ApplicationLogic.Base.Abstractions;
using Core.Model;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
