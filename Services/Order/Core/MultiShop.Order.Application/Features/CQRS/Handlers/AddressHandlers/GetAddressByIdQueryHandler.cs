﻿using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler(IRepository<Address> _repository)
    {
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query) 
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult 
            {
                Id = values.Id,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId,
            };
        }
    }
}
