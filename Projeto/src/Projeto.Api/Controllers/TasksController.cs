using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Tarefas;
using Projeto.Application.UseCases.Tarefas.CreateTarefa;
using Projeto.Application.UseCases.Tarefas.DeleteTarefa;
using Projeto.Application.UseCases.Tarefas.GetAllTarefa;
using Projeto.Application.UseCases.Tarefas.GetTarefa;
using Projeto.Application.UseCases.Tarefas.UpdateTarefa;

namespace Projeto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<TarefaResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllTarefaRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaResponse>> Get(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
            return BadRequest();

        var response = await _mediator.Send(new GetTarefaRequest(id.Value), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaResponse>> Create(CreateTarefaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaResponse>> Update(Guid id, UpdateTarefaRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
            return BadRequest();

        var response = await _mediator.Send(new DeleteTarefaRequest(id.Value), cancellationToken);
        return Ok(response);
    }
}
