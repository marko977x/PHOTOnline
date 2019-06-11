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
using PHOTOnline.Business.OrderManagement.Output;
using PHOTOnline.Services.Repositories.Orders;

namespace PHOTOnline.Web.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> PerformOrder([FromForm]PerformOrderInput input)
        {
            Result<string> result = await _orderManager.PerformOrderAsync(input);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            Result<OrderOutput> result = await _orderManager.GetOrderById(orderId);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            Result<List<OrderOutput>> result = await _orderManager.GetAllOrders();
            if (result.Success) return Ok(result);
            else return BadRequest(result);
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
            Result<List<OrderOutput>> result =
                await _orderManager.GetAllOrdersByUserIdAsync(userId);

            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompleted()
        {
            await _orderRepository.DeleteCompleted();
            return Ok(new Result() { Success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderState(
            [FromForm]UpdateOrderStateInput input)
        {
            Result result = await _orderManager.UpdateOrderState(input);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnresolvedOrders()
        {
            Result<List<OrderOutput>> result = await _orderManager.GetUnresolvedOrders();
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }
    }
}