using FluentValidation;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class ValidadorMedico : AbstractValidator<Medico>
    {
        public ValidadorMedico()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();
            RuleFor(x => x.Crm)
                .NotNull().NotEmpty()
                .Matches(@"^\d{5}-[A-Z]{2}$")
                .WithMessage("O campo Crm deve estar no formato válido (ex: 12345-AA).");
        }
    }
}
