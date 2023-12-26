using FluentValidation;

namespace Projeto.Application.UseCases.Tarefas.DeleteTarefa;

public class DeleteTarefaValidator : AbstractValidator<DeleteTarefaRequest>
{
    public DeleteTarefaValidator()
    {
        RuleFor(n => n.Id).NotEmpty();
    }
}
