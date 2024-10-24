﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail> _repository)
    {
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            value.ProductId = command.ProductId;
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductAmount = command.ProductAmount;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);

        }
    }
}
