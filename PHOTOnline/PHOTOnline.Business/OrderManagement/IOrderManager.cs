using PhotoLine.Domain.Interop;
using PHOTOnline.Business.OrderManagement.Input;
using PHOTOnline.Business.OrderManagement.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PHOTOnline.Business.OrderManagement
{
    public interface IOrderManager
    {
        Task<Result<string>> PerformOrderAsync(PerformOrderInput input);
        Task<Result<OrderOutput>> GetOrderById(string orderId);
        Task<Result> UpdateOrderState(UpdateOrderStateInput input);
        Task<Result<List<OrderOutput>>> GetAllOrdersByUserIdAsync(string userId);
        Task<Result<List<OrderOutput>>> GetAllOrders();
        Task<Result<List<OrderOutput>>> GetUnresolvedOrders();
    }
}
