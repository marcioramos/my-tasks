using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Tarefas.GetTarefa;

public sealed class GetTarefaHandler : IRequestHandler<GetTarefaRequest, TarefaResponse>
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;

    public GetTarefaHandler(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public async Task<TarefaResponse> Handle(GetTarefaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _tarefaRepository.Get(request.Id, cancellationToken);
        return _mapper.Map<TarefaResponse>(entity);
    }
}
