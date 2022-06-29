using Main.Models;

namespace Main.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoCliente> GetCarrinhoAsync(string carrinhoId);
        Task<CarrinhoCliente> UpdateCarrinhoAsync(CarrinhoCliente carrinho);
        Task<bool> DeleteCarrinhoAsync(string carrinhoId);
    }
}