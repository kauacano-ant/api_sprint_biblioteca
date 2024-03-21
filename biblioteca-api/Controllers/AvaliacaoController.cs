using biblioteca_api.Models;
using biblioteca_api.Repositorio;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_api.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _AvaliacaoRepositorio;
        public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepositorio)
        {
            _AvaliacaoRepositorio = avaliacaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AvaliacaoModel>>> BuscarTodasAvaliacao()
        {
            List<AvaliacaoModel> avaliacao = await _AvaliacaoRepositorio.BuscarTodasAvaliacao();
            return Ok(avaliacao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoModel>> BuscarPorId(int id)
        {
            AvaliacaoModel avaliacao = await _AvaliacaoRepositorio.BuscarPorId(id);
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<ActionResult<AvaliacaoModel>> Adicionar([FromBody] AvaliacaoModel avaliacaoModel)
        {
            AvaliacaoModel avaliacao = await _AvaliacaoRepositorio.Adicionar(avaliacaoModel);
            return Ok(avaliacao);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<AvaliacaoModel>> Atualizar(int id, [FromBody] AvaliacaoModel avaliacaoModel)
        {
            avaliacaoModel.Id = id;
            AvaliacaoModel avaliacao = await _AvaliacaoRepositorio.Atualizar(avaliacaoModel, id);
            return Ok(avaliacao);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<AvaliacaoModel>> Apagar(int id)
        {
            bool apagado = await _AvaliacaoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
