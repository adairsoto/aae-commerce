using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Main.Models;

namespace Main.Specifications
{
    public class ProdutoMarcaCatSpecification : BaseSpecification<Produto>
    {
        public ProdutoMarcaCatSpecification()
        {
            AddInclude(x => x.ProdutoMarca);
            AddInclude(x => x.ProdutoCategoria);
        }

        public ProdutoMarcaCatSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProdutoMarca);
            AddInclude(x => x.ProdutoCategoria);
        }
    }
}