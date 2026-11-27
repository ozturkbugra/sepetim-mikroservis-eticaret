using MediatR;
using Sepetim.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Sepetim.Order.Application.Features.Mediator.Results.OrderingResults;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                OrderingID = x.OrderingID,
                UserID = x.UserID,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,
            }).ToList();
        }
    }
}
