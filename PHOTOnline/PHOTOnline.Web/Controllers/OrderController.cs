using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoLine.Domain.Interop;
using PHOTOnline.Business.OrderManagement;
using PHOTOnline.Business.OrderManagement.Input;
using PHOTOnline.Services.Repositories.Orders;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderManager _orderManager;
        private IOrderRepository _orderRepository;

        public OrderController(
            IOrderManager orderManager,
            IOrderRepository orderRepository)
        {
            _orderManager = orderManager;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PerformOrder([FromBody]PerformOrderInput input)
        {
            Result<string> result = await _orderManager.PerformOrderAsync(input);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            Result<Order> result = await _orderManager.GetOrderById(orderId);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(new Result<List<Order>>()
            {
                Success = true,
                Data = await _orderRepository.GetAllOrders()
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
            return Ok(new Result() { Success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersByUserId(string userId)
        {
            return Ok(new Result<List<Order>>()
            {
                Data = await _orderRepository.GetOrdersByUserId(userId),
                Success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompleted()
        {
            await _orderRepository.DeleteCompleted();
            return Ok(new Result() { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderState(
            [FromBody]UpdateOrderStateInput input)
        {
            Result result = await _orderManager.UpdateOrderState(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }
    }
}