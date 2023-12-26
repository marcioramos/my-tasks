using Projeto.Domain.Entities;

namespace Projeto.Domain.Interfaces;

public interface ITarefaRepository : IBaseRepository<Tarefa>
{
    Task<Tarefa?> GetByNome(string nome, CancellationToken cancellationToken);
}
