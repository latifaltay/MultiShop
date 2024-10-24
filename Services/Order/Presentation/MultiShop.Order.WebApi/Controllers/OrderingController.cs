﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> OrderingList() 
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id) 
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);   
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id) 
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }


    }
}
