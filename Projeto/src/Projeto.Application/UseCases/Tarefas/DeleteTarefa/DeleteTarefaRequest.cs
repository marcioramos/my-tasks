using MediatR;

namespace Projeto.Application.UseCases.Tarefas.DeleteTarefa;

public sealed record DeleteTarefaRequest(Guid Id) : IRequest<TarefaResponse>;
