﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler(IRepository<OrderDetail> _repository)
    {
        public async Task Handle(CreateOrderDetailCommand command) 
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = command.OrderingId,
                ProductAmount = command.ProductAmount,
                ProductName = command.ProductName,
                ProductId = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
            });
        }
    }
}
