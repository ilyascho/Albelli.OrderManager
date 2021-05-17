using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Albelli.OrderManager.Application.CQRS.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderDbContext orderDbContext;
        private readonly IMapper mapper;

        public GetOrderByIdQueryHandler(IOrderDbContext orderDbContext, IMapper mapper)
        {
            this.orderDbContext = orderDbContext;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = orderDbContext.Orders
                                       .Include(o => o.OrderProducts)
                                       .ThenInclude(oi => oi.Product)
                                       .SingleOrDefault(a => a.Id == request.Id);

            return await Task.FromResult(mapper.Map<OrderDto>(order));
        }
    }
}
