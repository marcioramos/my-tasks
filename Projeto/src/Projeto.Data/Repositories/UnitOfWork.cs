using Projeto.Data.Context;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class UnitOfWork(ContextoBd contextoBd) : IUnitOfWork
{
    private readonly ContextoBd _contextoBd = contextoBd;

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _contextoBd.SaveChangesAsync(cancellationToken);
    }
}
