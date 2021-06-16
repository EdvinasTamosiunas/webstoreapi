using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using WebstoreAPI.Contracts;
using WebstoreAPI.Services;

namespace API.Controllers
{
    
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUriService _uriService;

        public OrderController(IOrderService orderService, IUriService uriService)
        {
            _orderService = orderService;
            _uriService = uriService;
        }

        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Orders.GetAll)]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            if (orders == null) return NoContent();
            return Ok(orders);
        }

        [Authorize(Roles = Role.API)]
        [HttpPost]
        [Route(ApiRoutes.Orders.PostOrder)]
        public async Task<IActionResult> PostOrder([FromBody] OrderRequest orderRequest)
        {
            var order = await _orderService.PostOrder(orderRequest);
            if (order == null) return BadRequest();
            var locationUri = _uriService.GetOrderUri(order.Id.ToString());
            return Created(locationUri, order);
        }
    }
}