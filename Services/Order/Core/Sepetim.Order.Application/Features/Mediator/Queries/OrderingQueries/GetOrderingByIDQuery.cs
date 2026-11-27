using MediatR;
using Sepetim.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Sepetim.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIDQuery: IRequest<GetOrderingByIDQueryResult>
    {
        public int Id { get; set; }

        public GetOrderingByIDQuery(int id)
        {
            Id = id;
        }
    }
}
