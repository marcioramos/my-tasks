using FluentValidation;

namespace Projeto.Application.UseCases.Tarefas.GetTarefa;

public class GetTarefaValidator : AbstractValidator<GetTarefaRequest>
{
    public GetTarefaValidator()
    {
        RuleFor(n => n.Id).NotEmpty();
    }
}
