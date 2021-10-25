using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;


namespace OnlineBookSubscription.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscriptionService service, IMapper mapper)
        {
            _subscriptionService = service;
            _mapper = mapper;

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Subscribe([FromBody] SubscribeDto subscribeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error occurred in the user input!");

            var subscribeObj
                = _mapper.Map<SubscribeDto, Subscription>(subscribeDto);

            var result = await _subscriptionService.AddSubscription(subscribeObj);

            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<bool>> UnSubscribe(UnsubscribeDto unsubscribeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Error occurred!");

            var result = await _subscriptionService.RemoveSubscription(unsubscribeDto);
            return Ok(result);
        }


    }
}