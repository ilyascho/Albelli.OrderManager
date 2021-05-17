using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Albelli.OrderManager.Application.CQRS.Orders.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {

    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderDbContext orderDbContext;
        private readonly IMapper mapper;

        public GetOrdersQueryHandler(IOrderDbContext storeDbContext, IMapper mapper)
        {
            this.orderDbContext = storeDbContext;
            this.mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = orderDbContext.Orders
                                       .Include(o => o.OrderProducts)
                                       .ThenInclude(oi => oi.Product)
                                       .ToList();

            return await Task.FromResult(mapper.Map<List<OrderDto>>(orders));
        }
    }
}
