using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{

    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public AutorRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<AutorModel> BuscarPorId(int id)
        {
            return await _dbcontext.Autor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AutorModel>> BuscarTodasAutor()
        {
            return await _dbcontext.Autor.ToListAsync();
        }
        public async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbcontext.Autor.AddAsync(autor);
            await _dbcontext.SaveChangesAsync();

            return autor;
        }

        public async Task<bool> Apagar(int id)
        {
            AutorModel autor = await BuscarPorId(id);

            if (autor == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Autor.Remove(autor);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<AutorModel> Atualizar(AutorModel autor, int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autorPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            autorPorId.Name = autor.Name;
            autorPorId.Nacionalidade = autor.Nacionalidade;
            autorPorId.DataNascimento = autor.DataNascimento;

            _dbcontext.Autor.Update(autorPorId);
            await _dbcontext.SaveChangesAsync();
            return autorPorId;
        }
    }
}
