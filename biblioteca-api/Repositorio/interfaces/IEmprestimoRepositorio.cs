using biblioteca_api.Models;

namespace biblioteca_api.Repositorio.interfaces
{
    public interface IEmprestimoRepositorio
    {
        Task<List<EmprestimoModel>> BuscarTodasEmprestimo();

        Task<EmprestimoModel> BuscarPorId(int id);

        Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo);

        Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id);

        Task<bool> Apagar(int id);
    }
}
