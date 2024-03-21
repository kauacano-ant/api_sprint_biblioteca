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
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraRepositorio _EditoraRepositorio;
        public EditoraController(IEditoraRepositorio editoraRepositorio)
        {
            _EditoraRepositorio = editoraRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EditoraModel>>> BuscarTodasEditora()
        {
            List<EditoraModel> editora = await _EditoraRepositorio.BuscarTodasEditora();
            return Ok(editora);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditoraModel>> BuscarPorId(int id)
        {
            EditoraModel editora = await _EditoraRepositorio.BuscarPorId(id);
            return Ok(editora);
        }

        [HttpPost]
        public async Task<ActionResult<EditoraModel>> Adicionar([FromBody] EditoraModel editoraModel)
        {
            EditoraModel editora = await _EditoraRepositorio.Adicionar(editoraModel);
            return Ok(editora);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<EditoraModel>> Atualizar(int id, [FromBody] EditoraModel editoraModel)
        {
            editoraModel.Id = id;
            EditoraModel editora = await _EditoraRepositorio.Atualizar(editoraModel, id);
            return Ok(editora);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<EditoraModel>> Apagar(int id)
        {
            bool apagado = await _EditoraRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
