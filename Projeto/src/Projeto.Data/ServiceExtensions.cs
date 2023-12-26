using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Data.Context;
using Projeto.Data.Repositories;
using Projeto.Domain.Interfaces;

namespace Projeto.Data;

public static class ServiceExtensions
{
    public static void ConfigureDataApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<ContextoBd>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITarefaRepository, TarefaRepository>();
    }
}
