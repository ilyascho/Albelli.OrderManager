using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Application.DTOs;
using Albelli.OrderManager.Application.Factories;
using Albelli.OrderManager.Domain.Orders;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Albelli.OrderManager.Application.CQRS.Orders.Command
{
    public class CreateOrderCommand : IRequest<OrderResponseDto>
    {
        public List<OrderProductDto> OrderProducts { get; set; }
    }

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.OrderProducts).NotEmpty().WithMessage("OrderProduct is empty");
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponseDto>
    {
        private readonly IOrderDbContext orderDbContext;
        private readonly IMapper mapper;
        
        public CreateOrderCommandHandler(IOrderDbContext storeDbContext, IMapper mapper)
        {
            this.orderDbContext = storeDbContext;
            this.mapper = mapper;
        }

        public async Task<OrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderProducts = new List<OrderProduct>();
            decimal requiredBinWidth = 0.0M;

            foreach (var orderProduct in request.OrderProducts)
            {
                var newOrderProduct = new OrderProduct
                {
                    Id = Guid.NewGuid(),
                    Quantity = orderProduct.Quantity,                    
                    Product = ProductFactory.Create(orderProduct.ProductType)
                };

                await orderDbContext.OrderProducts.AddAsync(newOrderProduct);
                
                orderProducts.Add(newOrderProduct);

                requiredBinWidth += newOrderProduct.Product.CalculateBinWidth(orderProduct.Quantity);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                RequiredBinWidth = requiredBinWidth
            };

            order.OrderProducts = orderProducts;

            await orderDbContext.Orders.AddAsync(order);

            await orderDbContext.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(mapper.Map<OrderResponseDto>(order));
        }
    }
}
