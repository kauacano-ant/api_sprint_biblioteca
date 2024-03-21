using biblioteca_api.Data;
using biblioteca_api.Models;
using biblioteca_api.Repositorio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Repositorio
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {


        private readonly SistemaBibliotecaDbContext _dbcontext;

        public AvaliacaoRepositorio(SistemaBibliotecaDbContext at_ApiDbContext)
        {
            _dbcontext = at_ApiDbContext;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbcontext.Avaliacao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacao()
        {
            return await _dbcontext.Avaliacao.ToListAsync();
        }
        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbcontext.Avaliacao.AddAsync(avaliacao);
            await _dbcontext.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacao = await BuscarPorId(id);

            if (avaliacao == null)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            _dbcontext.Avaliacao.Remove(avaliacao);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel AvaliacaoPorId = await BuscarPorId(id);
            if (AvaliacaoPorId == null
)
            {
                throw new Exception($"usuario do id:{id} nao foi encontrado ");
            }

            AvaliacaoPorId.Pontuacao = avaliacao.Pontuacao;
            AvaliacaoPorId.Comentario = avaliacao.Comentario;
            AvaliacaoPorId.DataAvaliacao = avaliacao.DataAvaliacao;

            _dbcontext.Avaliacao.Update(AvaliacaoPorId);
            await _dbcontext.SaveChangesAsync();
            return AvaliacaoPorId;
        }
    }

}
