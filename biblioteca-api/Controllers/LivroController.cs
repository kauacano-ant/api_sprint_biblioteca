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
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _LivroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _LivroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroModel>>> BuscarTodasLivro()
        {
            List<LivroModel> livro = await _LivroRepositorio.BuscarTodasLivro();
            return Ok(livro);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> BuscarPorId(int id)
        {
            LivroModel livro = await _LivroRepositorio.BuscarPorId(id);
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<LivroModel>> Adicionar([FromBody] LivroModel livroModel)
        {
            LivroModel livro = await _LivroRepositorio.Adicionar(livroModel);
            return Ok(livro);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<LivroModel>> Atualizar(int id, [FromBody] LivroModel livroModel)
        {
            livroModel.Id = id;
            LivroModel livro = await _LivroRepositorio.Atualizar(livroModel, id);
            return Ok(livro);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<LivroModel>> Apagar(int id)
        {
            bool apagado = await _LivroRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
