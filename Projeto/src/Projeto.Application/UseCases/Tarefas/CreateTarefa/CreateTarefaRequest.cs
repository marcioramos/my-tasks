using MediatR;

namespace Projeto.Application.UseCases.Tarefas.CreateTarefa;

public sealed record class CreateTarefaRequest(string Nome, string Descricao) : IRequest<TarefaResponse>;
