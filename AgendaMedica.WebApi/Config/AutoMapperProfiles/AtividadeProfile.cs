using AutoMapper;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.WebApi.ViewModels;

namespace AgendaMedica.WebApi.Config.AutoMapperProfiles
{
    public class AtividadeProfile : Profile
    {
        public AtividadeProfile()
        {
            CreateMap<Atividade, ListarAtividadeViewModel>();

            CreateMap<Atividade, VisualizarAtividadeViewModel>();


            CreateMap<FormsAtividadeViewModel, Atividade>()
                .AfterMap<ConfigurarMedicoMappingAction>();            
        }
    }

    public class ConfigurarMedicoMappingAction : IMappingAction<FormsAtividadeViewModel, Atividade>
    {
        private readonly IRepositorioMedico repositorioMedico;

        public ConfigurarMedicoMappingAction(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }

        public void Process(FormsAtividadeViewModel viewModel, Atividade nota, ResolutionContext context)
        {
            //nota.Medico = repositorioCategoria.SelecionarPorId(viewModel.CategoriaId);
        }
    }
}
