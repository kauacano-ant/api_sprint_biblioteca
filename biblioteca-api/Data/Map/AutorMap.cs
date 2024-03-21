using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_api.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<AutorModel>
    {
        public void Configure(EntityTypeBuilder<AutorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNascimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nacionalidade).IsRequired().HasMaxLength(255);
            
        }
    }
}
