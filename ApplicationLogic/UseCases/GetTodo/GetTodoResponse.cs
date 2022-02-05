using ApplicationLogic.Base.Abstractions;
using Core.Model;

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
