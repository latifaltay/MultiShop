using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OderingQueries
{
    public class GetOrderingByIdQuery(int id) : IRequest<List<GetOrderingByIdQueryResult>>
    {
        public int Id { get; set; } = id;   
    }
}
