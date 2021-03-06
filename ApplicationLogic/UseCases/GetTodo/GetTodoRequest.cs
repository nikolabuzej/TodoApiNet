using ApplicationLogic.Base.Abstractions;

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
