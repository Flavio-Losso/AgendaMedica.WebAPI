using Microsoft.EntityFrameworkCore;
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Infra.Orm.Compartilhado;

namespace AgendaMedica.Infra.Orm.ModuloAtividade
{
    public class RepositorioAtividadeOrm : RepositorioBase<Atividade>, IRepositorioAtividade
    {
        public RepositorioAtividadeOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override async Task<Atividade> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Medico).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
