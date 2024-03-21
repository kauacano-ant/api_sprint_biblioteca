using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<AvaliacaoModel>> BuscarTodasAvaliacao();

        Task<AvaliacaoModel> BuscarPorId(int id);

        Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao);

        Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id);

        Task<bool> Apagar(int id);
    }
}
