using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Tarefas.DeleteTarefa;

public sealed class DeleteTarefaHandler : IRequestHandler<DeleteTarefaRequest, TarefaResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;

    public DeleteTarefaHandler(IUnitOfWork unitOfWork, ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public async Task<TarefaResponse?> Handle(DeleteTarefaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _tarefaRepository.Get(request.Id, cancellationToken);

        if (entity == null) return default;

        _tarefaRepository.Delete(entity);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<TarefaResponse>(entity);
    }
}
