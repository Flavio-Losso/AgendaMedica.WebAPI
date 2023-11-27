using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.Dominio.ModuloAtividade
{
    public class Atividade : Entidade
    {
        public Atividade()
        {
            Medico = new List<Medico>();
        }
        public TipoAtividadeEnum TipodeAtividade { get; set; }
        public DateTime HoraInicio { get; set; }

        public DateTime HoraFim { get; set; }

        public string? Descricao { get; set; }

        public List<Medico> Medico { get; set; }
    }
}
