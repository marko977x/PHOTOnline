using Domain.Entities;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.OrderManagement.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Business.OrderManagement
{
    public interface IOrderManager
    {
        Task<Result<string>> PerformOrderAsync(PerformOrderInput input);
        Task<Result<Order>> GetOrderById(string orderId);
        Task<Result> UpdateOrderState(UpdateOrderStateInput input);
    }
}
