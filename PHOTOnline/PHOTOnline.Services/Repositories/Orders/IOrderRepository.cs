using Domain.Entities;
using PhotoLine.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PHOTOnline.Services.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetOrdersByUserId(string userId);
        System.Threading.Tasks.Task DeleteCompleted();
        Task<List<Order>> GetUnresolvedOrders();
    }
}
