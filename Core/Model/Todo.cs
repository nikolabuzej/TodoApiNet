namespace Core.Model
{
    public class Todo
    {
        public Guid Id { get; private set; }
        public string Text { get; set; } = "";
        public bool IsDone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }

        public Todo(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
            CreatedAt = DateTime.UtcNow;
        }


        public void MarkAsDone()
        {
            this.IsDone = true;
            this.FinishedAt = DateTime.UtcNow;
        }

    }
}
