using MediatR;
using Sepetim.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Sepetim.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {

    }
}
