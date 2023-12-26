using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;

namespace Projeto.Data.Context;

public class ContextoBd : DbContext
{
    public ContextoBd(DbContextOptions<ContextoBd> options) : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
}
