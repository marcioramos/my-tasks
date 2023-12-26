using FluentValidation;

namespace Projeto.Application.UseCases.Tarefas.GetAllTarefa;

public class GetAllTarefaValidator : AbstractValidator<GetAllTarefaRequest>
{
    public GetAllTarefaValidator()
    {
        //sem validação
    }
}
