using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public ProdutoCategoria ProdutoCategoria { get; set; }
        public int ProdutoCategoriaId { get; set; }
        public ProdutoMarca ProdutoMarca { get; set; }
        public int ProdutoMarcaId { get; set; }
    }
}

