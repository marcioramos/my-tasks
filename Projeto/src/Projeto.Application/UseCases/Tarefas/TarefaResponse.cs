namespace Projeto.Application.UseCases.Tarefas;

public sealed record TarefaResponse
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
}
