using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }
        public string? ImgUrl { get; set; }
        public int ProdutoMarcaId { get; set; }
        public ProdutoMarca? ProdutosMarca { get; set; }
        public int ProdutoCategoriaId { get; set; }
        public ProdutoCategoria? ProdutosCategoria { get; set; }
    }
}

