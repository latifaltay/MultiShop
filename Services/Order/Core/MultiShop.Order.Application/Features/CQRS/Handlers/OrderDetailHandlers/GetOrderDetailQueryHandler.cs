using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler(IRepository<OrderDetail> _repository)
    {
        public async Task<List<OrderDetail>> Handle(GetOrderDetailQueryHandler query) 
        {
            var values = await _repository.GetAllAsync();
            return values;
        }
    }
}
