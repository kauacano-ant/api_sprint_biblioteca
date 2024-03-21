using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<LivroModel>> BuscarTodasLivro();

        Task<LivroModel> BuscarPorId(int id);

        Task<LivroModel> Adicionar(LivroModel livro);

        Task<LivroModel> Atualizar(LivroModel livro, int id);

        Task<bool> Apagar(int id);
    }
}
