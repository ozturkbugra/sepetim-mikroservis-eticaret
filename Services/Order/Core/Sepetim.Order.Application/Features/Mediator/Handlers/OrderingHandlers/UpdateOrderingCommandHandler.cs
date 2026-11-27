using MediatR;
using Sepetim.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.OrderingID);

            value.OrderDate = request.OrderDate;
            value.TotalPrice = request.TotalPrice; 
            value.UserID = request.UserID;

            await _repository.UpdateAsync(value);
        }
    }
}
