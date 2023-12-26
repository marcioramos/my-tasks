using AutoMapper;
using Projeto.Application.UseCases.Tarefas.CreateTarefa;
using Projeto.Application.UseCases.Tarefas.DeleteTarefa;
using Projeto.Application.UseCases.Tarefas.GetAllTarefa;
using Projeto.Application.UseCases.Tarefas.GetTarefa;
using Projeto.Application.UseCases.Tarefas.UpdateTarefa;
using Projeto.Domain.Entities;

namespace Projeto.Application.UseCases.Tarefas;

public sealed class TarefaMapper : Profile
{
    public TarefaMapper()
    {
        CreateMap<CreateTarefaRequest, Tarefa>();
        CreateMap<DeleteTarefaRequest, Tarefa>();
        CreateMap<GetAllTarefaRequest, Tarefa>();
        CreateMap<GetTarefaRequest, Tarefa>();
        CreateMap<UpdateTarefaRequest, Tarefa>();

        CreateMap<Tarefa, TarefaResponse>();
    }
}
