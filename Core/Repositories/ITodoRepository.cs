using Core.Model;

namespace Core.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> GetById(Guid id);
        Task<List<Todo>> GetTodos();
        Task Insert(Todo todo);
        Task Update(Todo todo);
        Task Delete(Todo todo);
    }
}
