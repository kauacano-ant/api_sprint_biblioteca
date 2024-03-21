using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public EmprestimoRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Emprestimo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EmprestimoModel>> BuscarTodasEmprestimo()
        {
            return await _dbcontext.Emprestimo.ToListAsync();
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbcontext.Emprestimo.AddAsync(emprestimo);
            await _dbcontext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimo = await BuscarPorId(id);

            if (emprestimo == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Emprestimo.Remove(emprestimo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel EmprestimoPorId = await BuscarPorId(id);
            if (EmprestimoPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            EmprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
            EmprestimoPorId.DataDevolucao = emprestimo.DataDevolucao;
            EmprestimoPorId.Status = emprestimo.Status;

            _dbcontext.Emprestimo.Update(EmprestimoPorId);
            await _dbcontext.SaveChangesAsync();
            return EmprestimoPorId;
        }
    }
}
