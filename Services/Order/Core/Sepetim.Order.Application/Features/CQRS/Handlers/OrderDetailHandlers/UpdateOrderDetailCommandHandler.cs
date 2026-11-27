using Sepetim.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIDAsync(command.OrderDetailID);
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductAmount = command.ProductAmount;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingID = command.OrderingID;
            value.ProductID = command.ProductID;
            await _repository.UpdateAsync(value);
        }
    }
}
