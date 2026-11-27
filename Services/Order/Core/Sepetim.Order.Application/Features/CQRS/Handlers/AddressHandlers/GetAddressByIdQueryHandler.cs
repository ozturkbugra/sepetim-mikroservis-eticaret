using Sepetim.Order.Application.Features.CQRS.Queries.AddressQueries;
using Sepetim.Order.Application.Features.CQRS.Results.AddressResults;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIDQuery query)
        {
            var values = await _repository.GetByIDAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressID = values.AddressID,
                UserID = values.UserID,
                District = values.District,
                City = values.City,
                Detail = values.Detail
            };
        }
    }
}
