using Main.Models;

namespace Main.Specifications
{
    public class ProdutoFilterCountSpecification : BaseSpecification<Produto>
    {
        public ProdutoFilterCountSpecification(ProdutoSpecParams produtoParams)
        : base(x =>
                (string.IsNullOrEmpty(produtoParams.Search) || x.Nome.ToLower().Contains(produtoParams.Search)) &&
                (!produtoParams.MarcaId.HasValue || x.ProdutoMarcaId == produtoParams.MarcaId) &&
                (!produtoParams.CategId.HasValue || x.ProdutoCategoriaId == produtoParams.CategId)
            )
        {
        }
    }
}