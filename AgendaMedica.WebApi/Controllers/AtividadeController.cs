using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Aplicacao.ModuloAtividade;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.WebApi.ViewModels;

namespace AgendaMedica.WebApi.Controllers
{
    [Route("api/Atividades")]
    [ApiController]
    public class AtividadeController : ApiControllerBase
    {
        private readonly ServicoAtividade servicoAtividade;
        private readonly IMapper mapeador;

        public AtividadeController(ServicoAtividade servicoNota, IMapper mapeador)
        {
            this.servicoAtividade = servicoNota;
            this.mapeador = mapeador;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ListarAtividadeViewModel>) ,200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarTodos()
        {
            var AtividadesResult = await servicoAtividade.SelecionarTodosAsync();

            var viewModel = mapeador.Map<List<ListarAtividadeViewModel>>(AtividadesResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("visualiacao-completa/{id}")]
        [ProducesResponseType(typeof(VisualizarAtividadeViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> SelecionarPorId(Guid id)
        {
            var atividadeResult = await servicoAtividade.SelecionarPorIdAsync(id);

            if (atividadeResult.IsFailed)
                return NotFound(atividadeResult.Errors);

            var viewModel = mapeador.Map<VisualizarAtividadeViewModel>(atividadeResult.Value);

            return Ok(viewModel);
        }


        [HttpPost]
        [ProducesResponseType(typeof(InserirAtividadeViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Inserir(InserirAtividadeViewModel viewModel)
        {
            var atividade = mapeador.Map<Atividade>(viewModel);

            var notaResult = await servicoAtividade.InserirAsync(atividade);

            if (notaResult.IsFailed)
                return BadRequest(notaResult.Errors);

            return Ok(viewModel);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EditarAtividadeViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Editar(Guid id, EditarAtividadeViewModel viewModel)
        {
            var selecaoNotaResult = await servicoAtividade.SelecionarPorIdAsync(id);

            if (selecaoNotaResult.IsFailed)
                return NotFound(selecaoNotaResult.Errors);

            var nota = mapeador.Map(viewModel, selecaoNotaResult.Value);

            var notaResult = await servicoAtividade.EditarAsync(nota);

            if (notaResult.IsFailed)
                return BadRequest(notaResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var selecaoNotaResult = await servicoAtividade.SelecionarPorIdAsync(id);

            if (selecaoNotaResult.IsFailed)
                return NotFound(selecaoNotaResult.Errors);

            await servicoAtividade.ExcluirAsync(id);

            return Ok();
        }

    }
}
