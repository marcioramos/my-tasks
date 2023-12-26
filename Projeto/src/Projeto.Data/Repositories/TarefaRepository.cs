using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class TarefaRepository(ContextoBd contextoBd) : BaseRepository<Tarefa>(contextoBd), ITarefaRepository
{
    public async Task<Tarefa?> GetByNome(string nome, CancellationToken cancellationToken)
    {
        return await _contextoBd.Tarefas.FirstOrDefaultAsync(n => n.Nome == nome, cancellationToken);
    }
}
