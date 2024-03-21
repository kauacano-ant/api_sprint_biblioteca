using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_api.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio _AutorRepositorio;
        public AutorController(IAutorRepositorio autorRepositorio)
        {
            _AutorRepositorio = autorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorModel>>> BuscarTodasAutor()
        {
            List<AutorModel> autor = await _AutorRepositorio.BuscarTodasAutor();
            return Ok(autor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorModel>> BuscarPorId(int id)
        {
            AutorModel autor = await _AutorRepositorio.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult<AutorModel>> Adicionar([FromBody] AutorModel autorModel)
        {
            AutorModel autor = await _AutorRepositorio.Adicionar(autorModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<AutorModel>> Atualizar(int id, [FromBody] AutorModel autorModel)
        {
            autorModel.Id = id;
            AutorModel autor = await _AutorRepositorio.Atualizar(autorModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<AutorModel>> Apagar(int id)
        {
            bool apagado = await _AutorRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
