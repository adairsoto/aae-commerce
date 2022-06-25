using Main.Models;

namespace Main.Specifications
{
    public class ProdutoMarcaCatSpecification : BaseSpecification<Produto>
    {
        public ProdutoMarcaCatSpecification(ProdutoSpecParams produtoParams)
            : base(x =>
                (string.IsNullOrEmpty(produtoParams.Search) || x.Nome.ToLower().Contains(produtoParams.Search)) &&
                (!produtoParams.MarcaId.HasValue || x.ProdutoMarcaId == produtoParams.MarcaId) &&
                (!produtoParams.CategId.HasValue || x.ProdutoCategoriaId == produtoParams.CategId)
            )
        {
            AddInclude(x => x.ProdutoMarca);
            AddInclude(x => x.ProdutoCategoria);
            AddOrderBy(x => x.Nome);
            ApplyPaging(produtoParams.PageSize * (produtoParams.PageIndex -1), produtoParams.PageSize);

            if(!string.IsNullOrEmpty(produtoParams.Sort))
            {
                switch (produtoParams.Sort)
                {
                    case "precoAsc":
                        AddOrderBy(p => p.Preco);
                        break;
                    case "precoDesc":
                        AddOrderByDescending(p => p.Preco);
                        break;
                    default:
                        AddOrderBy(n => n.Nome);
                        break;        
                }
            } 
        }
        public ProdutoMarcaCatSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProdutoMarca);
            AddInclude(x => x.ProdutoCategoria);
        }
    }
}