using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Support.Data
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios  { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntregas { get; set; }
        public DbSet<ItemPedido> ItemPedidos  { get; set; }
        public DbSet<MetodoEntrega> MetodoEntregas { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<ProdutoMarca> ProdutoMarcas { get; set; }
    }
}