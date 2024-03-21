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
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepositorio _ReservaRepositorio;
        public ReservaController(IReservaRepositorio reservaRepositorio)
        {
            _ReservaRepositorio = reservaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservaModel>>> BuscarTodasReserva()
        {
            List<ReservaModel> reserva = await _ReservaRepositorio.BuscarTodasReserva();
            return Ok(reserva);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaModel>> BuscarPorId(int id)
        {
            ReservaModel reserva = await _ReservaRepositorio.BuscarPorId(id);
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaModel>> Adicionar([FromBody] ReservaModel reservaModel)
        {
            ReservaModel reserva = await _ReservaRepositorio.Adicionar(reservaModel);
            return Ok(reserva);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ReservaModel>> Atualizar(int id, [FromBody] ReservaModel reservaModel)
        {
            reservaModel.Id = id;
            ReservaModel reserva = await _ReservaRepositorio.Atualizar(reservaModel, id);
            return Ok(reserva);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ReservaModel>> Apagar(int id)
        {
            bool apagado = await _ReservaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
