using System.Threading.Tasks;
using Main.Models;
using Main.Models.OrderAggregate;

namespace Main.Interfaces
{
    public interface IPaymentService
    {
        Task<CarrinhoCliente> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
