using System.Threading.Tasks;
using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.OrderManagement.Input;
using PHOTOnline.Services.Repositories.Orders;

namespace PHOTOnline.Business.OrderManagement
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<Order>> GetOrderById(string orderId)
        {
            Order order = await _orderRepository.FindAsync(orderId);

            if (order == null) return new Result<Order>() { Success = false };
            else return new Result<Order>() { Success = true, Data = order };
        }

        public async Task<Result<string>> PerformOrderAsync(PerformOrderInput input)
        {
            Order order = new Order()
            {
                DeliveryAddress = input.DeliveryAddress,
                Products = input.Products,
                UserId = input.UserId
            };

            return new Result<string>()
            {
                Success = true,
                Data = await _orderRepository.CreateAsync(order)
            };
        }

        public async Task<Result> UpdateOrderState(UpdateOrderStateInput input)
        {
            Order order = await _orderRepository.FindAsync(input.OrderId);
            if (order == null) return new Result() { Success = false };

            order.RequestStatus = input.RequestStatus;
            await _orderRepository.UpdateAsync(order);
            return new Result() { Success = true };
        }
    }
}
