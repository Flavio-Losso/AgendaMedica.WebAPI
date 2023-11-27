using Microsoft.EntityFrameworkCore;
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Infra.Orm.Compartilhado;

namespace AgendaMedica.Infra.Orm.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedicoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {

        }

        public Medico SelecionarPorCrm(string crm)
        {
            return registros.SingleOrDefault(x => x.Crm == crm);
        }

        public override Medico SelecionarPorId(Guid id)
        {
            return registros.Include(x => x.Atividades).SingleOrDefault(x => x.Id == id);
        }

        public override async Task<Medico> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Atividades).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
