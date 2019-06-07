using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.OrderManagement.Input;
using PHOTOnline.Business.OrderManagement.Output;
using PHOTOnline.Services.Repositories.Orders;
using PHOTOnline.Services.Repositories.Users;

namespace PHOTOnline.Business.OrderManagement
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderManager(
            IOrderRepository orderRepository,
            IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<List<OrderOutput>>> GetAllOrdersByUserIdAsync(string userId)
        {
            List<Order> orders = await _orderRepository.GetOrdersByUserId(userId);

            if (orders.Count == 0)
                return new Result<List<OrderOutput>>() { Success = true };

            PHOTOnlineUser user = await _userRepository.FindAsync(userId);

            List<OrderOutput> result = new List<OrderOutput>();
            orders.ForEach(order =>
            {
                result.Add(new OrderOutput()
                {
                    Order = order,
                    Address = user.Address,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                });
            });

            return new Result<List<OrderOutput>>()
            {
                Success = true,
                Data = result
            };
        }

        public async Task<Result<OrderOutput>> GetOrderById(string orderId)
        {
            Order order = await _orderRepository.FindAsync(orderId);
            if (order == null) return new Result<OrderOutput>() { Success = false };

            PHOTOnlineUser user = await _userRepository.FindAsync(order.UserId);

            OrderOutput result = new OrderOutput()
            {
                Order = order,
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return new Result<OrderOutput>() { Success = true, Data = result };
        }

        public async Task<Result<string>> PerformOrderAsync(PerformOrderInput input)
        {
            Order order = new Order()
            {
                DeliveryAddress = input.DeliveryAddress,
                UserId = input.UserId,
                CartId = input.CartId,
                Date = input.Date,
                RequestStatus = RequestStatus.OnHold
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
