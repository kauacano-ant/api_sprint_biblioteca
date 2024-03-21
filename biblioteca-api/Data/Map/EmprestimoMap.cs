﻿using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca_api.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataDevolucao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataEmprestimo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LivroId);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Livro);
            builder.HasOne(x => x.Usuario);
        }
    }
}