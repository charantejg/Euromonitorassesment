using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
  
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Orders>> GetOrders()
        {
           return await _orderService.GetOrders();
        }

        [Authorize]
        [HttpGet("GetByEmail/{email}")]
        public async Task<IEnumerable<Orders>> GetByEmail(string email)
        {
            return await _orderService.GetByEmail(email);
        }

        [Authorize]
        [HttpGet("GetByOrder/{id}")]
        public async Task<Orders> GetByOrder(int id)
        {
            return await _orderService.GetByOrderId(id);
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CheckoutDto checkoutDto)
        {
            var result = await _orderService.Create(checkoutDto);
            if (result > 0)
                return Ok();
            else
                return StatusCode(500, "Internal error adding orders during checkout");
        }

        
    }
}
