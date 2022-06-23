using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;

namespace Main.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProdutosAsync();
        Task<IReadOnlyList<ProdutoMarca>> GetProdutoMarcasAsync();
        Task<IReadOnlyList<ProdutoCategoria>> GetProdutoCategoriasAsync();

    }
}