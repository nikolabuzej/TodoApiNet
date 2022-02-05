using ApplicationLogic.Base.Abstractions;

namespace ApplicationLogic.UseCases.DeleteTodo
{
    public class DeleteTodoRequest : IRequest
    {
        public DeleteTodoRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
