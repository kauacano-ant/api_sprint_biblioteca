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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }



        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodasUsuario()
        {
            List<UsuarioModel> usuario = await _UsuarioRepositorio.BuscarTodasUsuario();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _UsuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _UsuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<UsuarioModel>> Atualizar(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _UsuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _UsuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
