using Main.Models;
using Main.Models.OrderAggregate;
using Main.Interfaces;

namespace Support.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICarrinhoRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        public OrderService(ICarrinhoRepository basketRepo, IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int delieveryMethodId, string basketId, Address shippingAddress)
        {
            // get basket from repo
            var basket = await _basketRepo.GetCarrinhoAsync(basketId);

            // get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Itens)
            {
                var productItem = await _unitOfWork.Repository<Produto>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Nome, productItem.ImagemUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Preco, item.Quantidade);
                items.Add(orderItem);
            }

            // get delivery method from repo
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(delieveryMethodId);

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // check to see if order exists
            var spec = new OrderByPaymentIntentWithItemsSpecification(basket.PaymentIntentId);
            var existingOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);

            // create order
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, basket.PaymentIntentId);
            _unitOfWork.Repository<Order>().Add(order);

            if (existingOrder != null)
            {
                _unitOfWork.Repository<Order>().Delete(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
            }

            // TODO: save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;

            // return order
            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);

            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);

            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}
