using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class EditoraRepositorio : IEditoraRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public EditoraRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<EditoraModel> BuscarPorId(int id)
        {
            return await _dbcontext.Editora.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EditoraModel>> BuscarTodasEditora()
        {
            return await _dbcontext.Editora.ToListAsync();
        }
        public async Task<EditoraModel> Adicionar(EditoraModel editora)
        {
            await _dbcontext.Editora.AddAsync(editora);
            await _dbcontext.SaveChangesAsync();

            return editora;
        }

        public async Task<bool> Apagar(int id)
        {
            EditoraModel editora = await BuscarPorId(id);

            if (editora == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Editora.Remove(editora);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EditoraModel> Atualizar(EditoraModel editora, int id)
        {
            EditoraModel EditoraPorId = await BuscarPorId(id);
            if (EditoraPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            EditoraPorId.Nome = editora.Nome;
            EditoraPorId.Localizacao = editora.Localizacao;
            EditoraPorId.AnoFundacao = editora.AnoFundacao;

            _dbcontext.Editora.Update(EditoraPorId);
            await _dbcontext.SaveChangesAsync();
            return EditoraPorId;
        }
    }
}
