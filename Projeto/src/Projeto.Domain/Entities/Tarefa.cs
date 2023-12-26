namespace Projeto.Domain.Entities;

public sealed class Tarefa : BaseEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
}
