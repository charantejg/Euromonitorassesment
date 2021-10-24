using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{

    public class CartController : BaseApiController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Cart cart)
        {
            var result = await _cartService.Post(cart);
            if (result > 0)
                return result;
            else
                return StatusCode(500, "Error occurred when updating the cart");

        }

        [HttpGet("{userId}")]
        public async Task<CheckoutDto> Get(int userId)
        {
          return  await _cartService.Get(userId);
        }


        [HttpPost("Remove")]
        public async Task<ActionResult<int>> Remove(Cart cart)
        {
          var result = await _cartService.Remove(cart);

            if (result > 0)
                return result;
            else
                return StatusCode(500, "Error occurred when updating the cart");
        }

        [HttpPost("MaxCartIem")]
        public async Task<ActionResult<int>> MaxCartItem(Cart cart)
        {
            var result = await _cartService.GetMaxCartId(cart);

            if (result > 0)
                return result;
            else
                return StatusCode(500, "Error occurred when updating the cart");
        }

        [HttpGet("GetCartItems/{userId}")]
        public async Task<IEnumerable<Cart>> GetCartItems(int userId)
        {
            return await _cartService.GetCartItems(userId);
        }


        [HttpPost("RemoveCartItems")]
        public async Task<ActionResult> RemoveCartItems(IEnumerable<Cart> cart)
        {
            try
            {
                _cartService.RemoveCartItems(cart);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500, "Error occurred when removing the cart");
            }
               
        }


    }
}
