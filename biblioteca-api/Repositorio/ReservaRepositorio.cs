using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public ReservaRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbcontext.Reserva.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReservaModel>> BuscarTodasReserva()
        {
            return await _dbcontext.Reserva.ToListAsync();
        }
        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbcontext.Reserva.AddAsync(reserva);
            await _dbcontext.SaveChangesAsync();

            return reserva;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reserva = await BuscarPorId(id);

            if (reserva == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Reserva.Remove(reserva);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel ReservaPorId = await BuscarPorId(id);
            if (ReservaPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            ReservaPorId.DataReserva = reserva.DataReserva;
            ReservaPorId.Status = reserva.Status;
          

            _dbcontext.Reserva.Update(ReservaPorId);
            await _dbcontext.SaveChangesAsync();
            return ReservaPorId;
        }
    }
}
