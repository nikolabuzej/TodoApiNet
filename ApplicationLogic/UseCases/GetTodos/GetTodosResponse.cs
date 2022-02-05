using ApplicationLogic.Base.Abstractions;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.GetTodos
{
    public class GetTodosResponse : IResponse
    {
        public GetTodosResponse(IEnumerable<Todo> todos)
        {
            Todos = todos ?? new List<Todo>();
        }

        public IEnumerable<Todo> Todos { get; set; } = new List<Todo>();
    }
}
