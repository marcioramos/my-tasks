using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Tarefas.GetAllTarefa;

public sealed class GetAllTarefaHandler : IRequestHandler<GetAllTarefaRequest, List<TarefaResponse>>
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;

    public GetAllTarefaHandler(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public async Task<List<TarefaResponse>> Handle(GetAllTarefaRequest request, CancellationToken cancellationToken)
    {
        var entities = await _tarefaRepository.GetAll(cancellationToken);
        return _mapper.Map<List<TarefaResponse>>(entities);
    }
}
