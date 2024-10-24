﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> _repository)
    {
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query) 
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductTotalPrice = value.ProductTotalPrice,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductId = value.ProductId,
                ProductAmount = value.ProductAmount,
                OrderingId = value.OrderingId,
                Id = value.Id,
            };
        }
    }
}
