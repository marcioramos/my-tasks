using AutoMapper;
using Moq;
using Projeto.Application.Shared.Exceptions;
using Projeto.Application.UseCases.Tarefas.CreateTarefa;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Tests;

public class TarefaTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<ITarefaRepository> _tarefaRepository;
    private readonly Mock<IMapper> _mapper;

    public TarefaTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _tarefaRepository = new Mock<ITarefaRepository>();
        _mapper = new Mock<IMapper>();
    }

    [Fact(DisplayName = "Nova tarefa válida")]
    [Trait("Categoria", "Tarefa")]
    public void Tarefa_Valida()
    {
        // Arrange
        var request = new CreateTarefaRequest("tarefa01", "Descrição da tarefa 01");
        var tarefaHandler = new CreateTarefaHandler(_unitOfWork.Object, _tarefaRepository.Object, _mapper.Object);

        // Act
        var result = tarefaHandler.Handle(request, new CancellationToken());

        // Assert
        _tarefaRepository.Verify(n => n.Create(It.IsAny<Tarefa>()), Times.Once);
        _unitOfWork.Verify(n => n.Commit(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "Tarefa já cadastrada.")]
    [Trait("Categoria", "Tarefa")]
    public async void Tarefa_Ja_Cadastrada()
    {
        // Arrange
        var request = new CreateTarefaRequest("", "");
        var tarefaHandler = new CreateTarefaHandler(_unitOfWork.Object, _tarefaRepository.Object, _mapper.Object);

        _tarefaRepository.Setup(n => n.GetByNome(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Tarefa());

        // Act
        var exception = await Assert.ThrowsAsync<DomainException>(() => tarefaHandler.Handle(request, new CancellationToken()));

        // Assert
        Assert.Equal("Tarefa já cadastrada.", exception.Message);
    }
}
