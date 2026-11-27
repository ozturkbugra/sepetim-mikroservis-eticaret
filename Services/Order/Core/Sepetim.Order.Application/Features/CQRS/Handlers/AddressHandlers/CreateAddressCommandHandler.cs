using Sepetim.Order.Application.Features.CQRS.Commands.AddressCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {

            await _repository.CreateAsync(new Address
            {
                UserID = command.UserID,
                District = command.District,
                City = command.City,
                Detail = command.Detail
            });
        }
    }
}
