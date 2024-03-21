using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IAutorRepositorio
    {
        Task<List<AutorModel>> BuscarTodasAutor();

        Task<AutorModel> BuscarPorId(int id);

        Task<AutorModel> Adicionar(AutorModel autor);

        Task<AutorModel> Atualizar(AutorModel autor, int id);

        Task<bool> Apagar(int id);
      
    }
}
