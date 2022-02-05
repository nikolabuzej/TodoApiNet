using ApplicationLogic.Base.Abstractions;

namespace ApplicationLogic.UseCases.MarkTodoAsDone
{
    public class MarkTodoAsDoneRequest : IRequest
    {
        public MarkTodoAsDoneRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
