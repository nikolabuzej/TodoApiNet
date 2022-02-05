using ApplicationLogic.Base.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.GetTodo
{
    public class GetTodoRequest : IRequest
    {
        public GetTodoRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
