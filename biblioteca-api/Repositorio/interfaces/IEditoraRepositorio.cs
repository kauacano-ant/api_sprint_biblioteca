using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IEditoraRepositorio
    {
        Task<List<EditoraModel>> BuscarTodasEditora();

        Task<EditoraModel> BuscarPorId(int id);

        Task<EditoraModel> Adicionar(EditoraModel editora);

        Task<EditoraModel> Atualizar(EditoraModel editora, int id);

        Task<bool> Apagar(int id);
    }
}
