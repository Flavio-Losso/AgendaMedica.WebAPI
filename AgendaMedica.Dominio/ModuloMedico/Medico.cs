using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloAtividade;

namespace AgendaMedica.Dominio.ModuloMedico
{
    public class Medico : Entidade
    {
        public Medico()
        {
            Atividades = new List<Atividade>();
        }
        public string Nome { get; set; }
        public string Crm { get; set; }

        public List<Atividade> Atividades { get; set; }

        public Atividade? UltimaAtividade { get; set; }

        public bool PodeRealizarAtividade()
        {
            if (Atividades == null)
                return true;

            TimeSpan RecuperacaoCirurgia = TimeSpan.FromHours(4);
            TimeSpan RecuperacaoConsulta = TimeSpan.FromMinutes(20);

            var TipoDaUltimaAtividade = UltimaAtividade.TipodeAtividade;
            var TempoDesdeUltimaAtividade = DateTime.Now - UltimaAtividade.HoraFim;

            if (TipoDaUltimaAtividade == TipoAtividadeEnum.Cirurgia && TempoDesdeUltimaAtividade >= RecuperacaoCirurgia)
                return true;
            if (TipoDaUltimaAtividade == TipoAtividadeEnum.Consulta && TempoDesdeUltimaAtividade >= RecuperacaoConsulta)
                return true;

            return false;
        }
    }
    
}
