using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaBibliotecaDbContext _dbcontext;

        public UsuarioRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodasUsuario()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel livro)
        {
            await _dbcontext.Usuarios.AddAsync(livro);
            await _dbcontext.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel livro = await BuscarPorId(id);

            if (livro == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Usuarios.Remove(livro);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel UsuarioPorId = await BuscarPorId(id);
            if (UsuarioPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            UsuarioPorId.Login = usuario.Login;
            UsuarioPorId.Senha = usuario.Senha;
           

            _dbcontext.Usuarios.Update(UsuarioPorId);
            await _dbcontext.SaveChangesAsync();
            return UsuarioPorId;
        }
    }
}
