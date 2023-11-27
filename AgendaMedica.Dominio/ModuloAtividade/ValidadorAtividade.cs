using FluentValidation;

namespace AgendaMedica.Dominio.ModuloAtividade
{
    public class ValidadorAtividade : AbstractValidator<Atividade>
    {
        public ValidadorAtividade()
        {
            RuleFor(x => x.HoraInicio)
               .NotNull().NotEmpty();

            RuleFor(x => x.HoraFim)
               .NotNull().NotEmpty();

            RuleFor(x => x.Medico)
               .NotNull().NotEmpty();
        }
    }
}
