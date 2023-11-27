using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Dominio.ModuloAtividade;

namespace AgendaMedica.WebApi.ViewModels
{
    public class ListarAtividadeViewModel
    {
        public Guid Id { get; set; }
        public TipoAtividadeEnum TipodeAtividade { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string? Descricao { get; set; }
    }

    public class VisualizarAtividadeViewModel
    {
        public TipoAtividadeEnum TipodeAtividade { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string? Descricao { get; set; }

        public List<ListarMedicoViewModel> Medicos { get; set; }

    }

    public class FormsAtividadeViewModel
    {
        public TipoAtividadeEnum TipodeAtividade { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string? Descricao { get; set; }

        //public Guid MedicoID { get; set; }
    }

    public class InserirAtividadeViewModel : FormsAtividadeViewModel
    {       
    }

    public class EditarAtividadeViewModel : FormsAtividadeViewModel
    {      
    }
}
