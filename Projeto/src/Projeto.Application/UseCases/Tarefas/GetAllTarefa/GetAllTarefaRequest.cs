using MediatR;

namespace Projeto.Application.UseCases.Tarefas.GetAllTarefa;

public sealed record GetAllTarefaRequest : IRequest<List<TarefaResponse>>;
