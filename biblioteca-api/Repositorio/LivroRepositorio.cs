using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public LivroRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbcontext.Livro.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodasLivro()
        {
            return await _dbcontext.Livro.ToListAsync();
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbcontext.Livro.AddAsync(livro);
            await _dbcontext.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livro = await BuscarPorId(id);

            if (livro == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Livro.Remove(livro);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel LivroPorId = await BuscarPorId(id);
            if (LivroPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            LivroPorId.Titulo = livro.Titulo;
            LivroPorId.Genero = livro.Genero;
            LivroPorId.AnoPublicacao = livro.AnoPublicacao;
            LivroPorId.ISBN = livro.ISBN;
            LivroPorId.Sinopse = livro.Sinopse;

            _dbcontext.Livro.Update(LivroPorId);
            await _dbcontext.SaveChangesAsync();
            return LivroPorId;
        }
    }
}
