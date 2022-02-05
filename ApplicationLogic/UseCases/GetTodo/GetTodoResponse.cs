using ApplicationLogic.Base.Abstractions;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.GetTodo
{
    public class GetTodoResponse : IResponse
    {
        public GetTodoResponse(Todo? todo)
        {
            Todo = todo;
        }

        public Todo? Todo { get; set; }
    }
}
