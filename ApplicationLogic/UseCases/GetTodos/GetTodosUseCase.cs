using ApplicationLogic.Base.Abstractions;
using Core.Model;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.GetTodos
{
    public class GetTodosUseCase : IUseCase<GetTodosRequest, GetTodosResponse>
    {
        private readonly ITodoRepository todoRepository;
        public GetTodosUseCase(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<GetTodosResponse> ExecuteAsync(GetTodosRequest request)
        {
            IEnumerable<Todo> todos = await this.todoRepository.GetTodos();

            return new(todos);
        }
    }
}
