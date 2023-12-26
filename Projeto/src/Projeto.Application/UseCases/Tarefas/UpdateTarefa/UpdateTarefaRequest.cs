using MediatR;

namespace Projeto.Application.UseCases.Tarefas.UpdateTarefa;

public sealed record UpdateTarefaRequest(Guid Id, string Nome, string Descricao) : IRequest<TarefaResponse>;
