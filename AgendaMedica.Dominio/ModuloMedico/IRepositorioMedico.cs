using AgendaMedica.Dominio.Compartilhado;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        public Medico SelecionarPorCrm(string crm);
    }
}
