using FluentValidation;

namespace Projeto.Application.UseCases.Tarefas.CreateTarefa;

public sealed class CreateTarefaValidator : AbstractValidator<CreateTarefaRequest>
{
    public CreateTarefaValidator()
    {
        RuleFor(n => n.Nome).NotEmpty().MaximumLength(50);
        RuleFor(n => n.Descricao).MaximumLength(250);
    }
}
