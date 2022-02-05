using ApplicationLogic.Base.Abstractions;

namespace ApplicationLogic.UseCases.UpdateTodo
{
    public class UpdateTodoRequest : IRequest
    {
        public UpdateTodoRequest(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public Guid Id { get; set; }
        public string Text { get; set; } = "";

    }
}
