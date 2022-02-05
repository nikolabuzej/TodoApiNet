using ApplicationLogic.Base.Abstractions;
using ApplicationLogic.UseCases.CreateTodo;
using ApplicationLogic.UseCases.GetTodo;
using ApplicationLogic.UseCases.GetTodos;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTodo
            (
               [FromServices] IUseCase<CreateTodoRequest> useCase,
               [FromBody] CreateTodoRequest request
            )
        {
            await useCase.ExecuteAsync(request);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos
            (
              [FromServices] IUseCase<GetTodosRequest, GetTodosResponse> useCase
            )
        {
            GetTodosResponse response = await useCase.ExecuteAsync(new());

            return response.Todos;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Todo>> GetTodo
            (
              [FromRoute] Guid id,
              [FromServices] IUseCase<GetTodoRequest, GetTodoResponse> useCase
            )
        {
            GetTodoResponse? response = await useCase.ExecuteAsync(new(id));

            if (response.Todo == null)
            {
                return NotFound();
            }

            return response.Todo;
        }
    }
}
