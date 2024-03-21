using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_api.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Pontuacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataAvaliacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LivroId);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Livro);
            builder.HasOne(x => x.Usuario);
        }
    }
}
