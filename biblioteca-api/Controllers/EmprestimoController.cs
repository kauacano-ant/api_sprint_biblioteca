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
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepositorio _EmprestimoRepositorio;
        public EmprestimoController(IEmprestimoRepositorio EmprestimoRepositorio)
        {
            _EmprestimoRepositorio = EmprestimoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmprestimoModel>>> BuscarTodasEmprestimo()
        {
            List<EmprestimoModel> emprestimo = await _EmprestimoRepositorio.BuscarTodasEmprestimo();
            return Ok(emprestimo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmprestimoModel>> BuscarPorId(int id)
        {
            EmprestimoModel emprestimo = await _EmprestimoRepositorio.BuscarPorId(id);
            return Ok(emprestimo);
        }

        [HttpPost]
        public async Task<ActionResult<EmprestimoModel>> Adicionar([FromBody] EmprestimoModel emprestimoModel)
        {
            EmprestimoModel emprestimo = await _EmprestimoRepositorio.Adicionar(emprestimoModel);
            return Ok(emprestimo);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<EmprestimoModel>> Atualizar(int id, [FromBody] EmprestimoModel emprestimoModel)
        {
            emprestimoModel.Id = id;
            EmprestimoModel emprestimo = await _EmprestimoRepositorio.Atualizar(emprestimoModel, id);
            return Ok(emprestimo);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<EmprestimoModel>> Apagar(int id)
        {
            bool apagado = await _EmprestimoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
