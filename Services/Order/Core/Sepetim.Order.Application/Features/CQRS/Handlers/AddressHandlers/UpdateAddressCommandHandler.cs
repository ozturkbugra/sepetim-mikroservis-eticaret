using Sepetim.Order.Application.Features.CQRS.Commands.AddressCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIDAsync(command.AddressID);
            value.District = command.District;
            value.City = command.City;
            value.Detail = command.Detail;
            value.UserID = command.UserID;
            await _repository.UpdateAsync(value);
        }
    }
}
