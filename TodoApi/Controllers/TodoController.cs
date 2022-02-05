using ApplicationLogic.Base.Abstractions;
using ApplicationLogic.UseCases.CreateTodo;
using ApplicationLogic.UseCases.DeleteTodo;
using ApplicationLogic.UseCases.GetTodo;
using ApplicationLogic.UseCases.GetTodos;
using ApplicationLogic.UseCases.MarkTodoAsDone;
using ApplicationLogic.UseCases.UpdateTodo;
using Core.Exceptions;
using Core.Model;
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
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> MarkTodoAsDone
            (
             [FromRoute] Guid id,
             [FromServices] IUseCase<MarkTodoAsDoneRequest> useCase
            )
        {
            try
            {
                await useCase.ExecuteAsync(new(id));
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo
            (
              [FromRoute] Guid id,
              [FromBody] string text,
              [FromServices] IUseCase<UpdateTodoRequest> useCase
            )
        {
            try
            {
                await useCase.ExecuteAsync(new(id, text));
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo
            (
                [FromRoute] Guid id,
                [FromServices] IUseCase<DeleteTodoRequest> useCase
            )
        {
            try
            {
                await useCase.ExecuteAsync(new(id));
            }
            catch (TodoNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
