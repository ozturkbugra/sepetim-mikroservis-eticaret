using Sepetim.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductAmount = command.ProductAmount,
                ProductID = command.ProductID,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingID = command.OrderingID
            });
        }
    }
}
