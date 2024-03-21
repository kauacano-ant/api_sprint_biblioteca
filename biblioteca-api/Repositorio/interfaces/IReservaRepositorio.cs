using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IReservaRepositorio
    {
        Task<List<ReservaModel>> BuscarTodasReserva();

        Task<ReservaModel> BuscarPorId(int id);

        Task<ReservaModel> Adicionar(ReservaModel reserva);

        Task<ReservaModel> Atualizar(ReservaModel reserva, int id);

        Task<bool> Apagar(int id);
    }
}
