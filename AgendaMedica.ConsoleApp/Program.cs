using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AgendaMedica.Aplicacao.ModuloMedico;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Infra.Orm.Compartilhado;
using AgendaMedica.Infra.Orm.ModuloMedico;
using AgendaMedica.Infra.Orm.ModuloAtividade;

namespace AgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var novoMedico = new Medico();
            novoMedico.Nome = "Fulano";
            novoMedico.Crm = "123456-AA";
            var novaAtividade = new Atividade();
            novaAtividade.HoraInicio = DateTime.Now;
            novaAtividade.HoraFim = DateTime.Now + TimeSpan.FromHours(2);
            novaAtividade.TipodeAtividade = TipoAtividadeEnum.Consulta;
            novaAtividade.Descricao = "Consulta com a dona marilene";
            novaAtividade.Medico.Add(novoMedico);

            var optionsBuilder = new DbContextOptionsBuilder<AgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=AgendaMedica;Integrated Security=True");

            var dbContext = new AgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.Add(novoMedico);

            dbContext.SaveChanges();


            novoMedico.UltimaAtividade = novaAtividade;
            novoMedico.Atividades.Add(novaAtividade);
            RepositorioMedicoOrm repositorioMedico = new RepositorioMedicoOrm(dbContext);


            dbContext.Add(novaAtividade);
            dbContext.SaveChanges();
            ServicoMedico servico = new ServicoMedico(repositorioMedico, dbContext);
            servico.EditarAsync(novoMedico);
        }
    }
}