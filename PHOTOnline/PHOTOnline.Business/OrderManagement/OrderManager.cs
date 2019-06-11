using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Enums;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.CartManagement;
using PHOTOnline.Business.OrderManagement.Input;
using PHOTOnline.Business.OrderManagement.Output;
using PHOTOnline.Domain.Entities;
using PHOTOnline.Services.Repositories.Carts;
using PHOTOnline.Services.Repositories.Orders;
using PHOTOnline.Services.Repositories.Users;

namespace PHOTOnline.Business.OrderManagement
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartManager _cartManager;

        public OrderManager(
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            ICartRepository cartRepository,
            ICartManager cartManager)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _cartManager = cartManager;
        }

        public async Task<Result<List<OrderOutput>>> GetAllOrders()
        {
            List<Order> orders = await _orderRepository.GetAllOrders();
            if (orders.Count == 0)
                return new Result<List<OrderOutput>>()
                {
                    Success = true,
                    Data = new List<OrderOutput>()
                };

            List<PHOTOnlineUser> users = await _userRepository.GetAllUsers();
            List<OrderOutput> result = new List<OrderOutput>();

            orders.ForEach(order =>
            {
                PHOTOnlineUser user = users.Find(element => element.Id == order.UserId);
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

        public async Task<Result<List<OrderOutput>>> GetAllOrdersByUserIdAsync(string userId)
        {
            List<Order> orders = await _orderRepository.GetOrdersByUserId(userId);

            if (orders.Count == 0)
                return new Result<List<OrderOutput>>() { Success = true };

            PHOTOnlineUser user = await _userRepository.FindAsync(userId);
            List<OrderOutput> result = new List<OrderOutput>();
            //List<Cart> carts = await _cartRepository.GetAll();

            orders.ForEach(order =>
            {
                //Cart cart = carts.Find(element => element.UserId == user.Id);
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
                CartItems = input.CartItems,
                Price = input.Price,
                DeliveryAddress = input.DeliveryAddress,
                UserId = input.UserId,
                Date = input.Date,
                RequestStatus = RequestStatus.OnHold,
                Notification = ""
            };

            await _cartManager.ClearCart(input.UserId);

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
            order.Notification = input.Notification;
            await _orderRepository.UpdateAsync(order);
            return new Result() { Success = true };
        }
    }
}
