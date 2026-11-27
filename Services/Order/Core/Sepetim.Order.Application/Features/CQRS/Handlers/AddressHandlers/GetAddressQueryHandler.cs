using Sepetim.Order.Application.Features.CQRS.Results.AddressResults;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressID = x.AddressID,
                UserID = x.UserID,
                District = x.District,
                City = x.City,
                Detail = x.Detail
            }).ToList();
        }
    }
}
