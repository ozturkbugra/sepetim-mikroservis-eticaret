using Sepetim.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Sepetim.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Sepetim.Order.Application.Interfaces;
using Sepetim.Order.Domain.Entities;

namespace Sepetim.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIDQueryResult> Handle(GetOrderDetailByIDQuery query)
        {
            var values = await _repository.GetByIDAsync(query.Id);
            return new GetOrderDetailByIDQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductAmount = values.ProductAmount,
                ProductTotalPrice = values.ProductTotalPrice,
                OrderingID = values.OrderingID
            };
        }
    }
}
