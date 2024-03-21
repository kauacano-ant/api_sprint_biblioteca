using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodasUsuario();

        Task<UsuarioModel> BuscarPorId(int id);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        Task<bool> Apagar(int id);
    }
}
