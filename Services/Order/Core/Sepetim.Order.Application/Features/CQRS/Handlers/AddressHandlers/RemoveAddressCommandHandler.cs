using Sepetim.Order.Application.Features.CQRS.Commands.AddressCommands;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await _repository.GetByIDAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
