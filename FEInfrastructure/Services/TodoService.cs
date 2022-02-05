using FECore.Abstractions.Services;
using FECore.Domain;
using Newtonsoft.Json;

namespace FEInfrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient httpClient;
        public TodoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            HttpResponseMessage? response = await this.httpClient.GetAsync("http://localhost:5112/api/Todo");

            var todos = await this.DeserializeTodos(response);

            return todos;
        }

        private async Task<IEnumerable<Todo>> DeserializeTodos(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<Todo>>(json);
            }
            catch (Exception e)
            {

                throw;
            }

            return new List<Todo>();
        }
    }
}
