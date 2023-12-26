using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Tarefas.CreateTarefa;

public class CreateTarefaHandler(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper) : IRequestHandler<CreateTarefaRequest, TarefaResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITarefaRepository _tarefaRepository = tarefaRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<TarefaResponse> Handle(CreateTarefaRequest request, CancellationToken cancellationToken)
    {
        await TaskAlreadyRegistered(request, cancellationToken);

        var entity = _mapper.Map<Tarefa>(request);

        _tarefaRepository.Create(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<TarefaResponse>(entity);
    }

    private async Task TaskAlreadyRegistered(CreateTarefaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _tarefaRepository.GetByNome(request.Nome, cancellationToken);
        if (entity != null)
        {
            throw new DomainException("Tarefa já cadastrada.");
        }
    }
}
