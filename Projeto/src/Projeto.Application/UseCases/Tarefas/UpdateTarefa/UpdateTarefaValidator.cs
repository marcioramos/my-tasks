using FluentValidation;

namespace Projeto.Application.UseCases.Tarefas.UpdateTarefa;

public class UpdateTarefaValidator : AbstractValidator<UpdateTarefaRequest>
{
    public UpdateTarefaValidator()
    {
        RuleFor(n => n.Nome).NotEmpty().MaximumLength(50);
        RuleFor(n => n.Descricao).MaximumLength(250);
    }
}
