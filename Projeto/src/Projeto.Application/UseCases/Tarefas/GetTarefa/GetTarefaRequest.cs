using MediatR;

namespace Projeto.Application.UseCases.Tarefas.GetTarefa;

public sealed record GetTarefaRequest(Guid Id) : IRequest<TarefaResponse>;
