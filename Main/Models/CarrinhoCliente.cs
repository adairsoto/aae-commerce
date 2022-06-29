namespace Main.Models
{
    public class CarrinhoCliente
    {
        public CarrinhoCliente()
        {
        }

        public CarrinhoCliente(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<CarrinhoItem> Itens { get; set; }  = new List<CarrinhoItem>();  
    }
}