using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Support.Data.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Preco).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ImagemUrl).IsRequired();
            builder.HasOne(m => m.ProdutoMarca).WithMany()
                   .HasForeignKey(p => p.ProdutoMarcaId);
            builder.HasOne(c => c.ProdutoCategoria).WithMany()
                   .HasForeignKey(p => p.ProdutoCategoriaId);       
        }
    }
}