using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Main.Models;
using Main.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Support.Data
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoMarca> ProdutoMarcas { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        
    }
}