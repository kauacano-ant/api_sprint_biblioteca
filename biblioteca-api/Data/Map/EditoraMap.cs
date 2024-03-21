using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_api.Data.Map
{
    public class EditoraMap : IEntityTypeConfiguration<EditoraModel>
    {
        public void Configure(EntityTypeBuilder<EditoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoFundacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Localizacao).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Livros);
        }
    }
}
