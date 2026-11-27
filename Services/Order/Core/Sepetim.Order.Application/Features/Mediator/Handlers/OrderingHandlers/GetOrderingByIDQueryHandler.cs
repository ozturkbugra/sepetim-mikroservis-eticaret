using MediatR;
using Sepetim.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Sepetim.Order.Application.Features.Mediator.Results.OrderingResults;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIDQueryHandler : IRequestHandler<GetOrderingByIDQuery, GetOrderingByIDQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIDQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIDQueryResult> Handle(GetOrderingByIDQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetOrderingByIDQueryResult
            {
                OrderingID = value.OrderingID,
                UserID = value.UserID,
                TotalPrice = value.TotalPrice,
                OrderDate = value.OrderDate,
            };
        }
    }
}
