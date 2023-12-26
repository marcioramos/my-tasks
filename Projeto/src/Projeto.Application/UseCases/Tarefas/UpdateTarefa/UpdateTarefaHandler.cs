using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Tarefas.UpdateTarefa;

public class UpdateTarefaHandler(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper) : IRequestHandler<UpdateTarefaRequest, TarefaResponse?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<TarefaResponse?> Handle(UpdateTarefaRequest request, CancellationToken cancellationToken)
    {
        await TaskAlreadyRegistered(request, cancellationToken);

        var entity = await _tarefaRepository.Get(request.Id, cancellationToken);

        if (entity is null) return default;

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;

        _tarefaRepository.Update(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<TarefaResponse>(entity);
    }

    private async Task TaskAlreadyRegistered(UpdateTarefaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _tarefaRepository.GetByNome(request.Nome, cancellationToken);
        if (entity != null && entity.Id != request.Id)
        {
            throw new DomainException("Tarefa já cadastrada.");
        }
    }
}

