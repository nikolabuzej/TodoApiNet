using ApplicationLogic.Base.Abstractions;

namespace ApplicationLogic.UseCases.CreateTodo
{
    public class CreateTodoRequest : IRequest
    {
        public string Text { get; private set; }

        public CreateTodoRequest(string text)
        {
            Text = text;
        }
    }
}
