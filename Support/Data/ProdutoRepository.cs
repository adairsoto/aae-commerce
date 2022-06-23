using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Interfaces;
using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Support.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaContext _context;
        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.ProdutoCategoria)
                .Include(p => p.ProdutoMarca)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProdutoCategoria>> GetProdutoCategoriasAsync()
        {
            return await _context.ProdutoCategorias.ToListAsync();
        }

        public async Task<IReadOnlyList<ProdutoMarca>> GetProdutoMarcasAsync()
        {
            return await _context.ProdutoMarcas.ToListAsync();
        }

        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos
                .Include(p => p.ProdutoCategoria)
                .Include(p => p.ProdutoMarca)
                .ToListAsync();
        }
    }
}