namespace Sepetim.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIDQuery
    {
        public int Id { get; set; }

        public GetOrderDetailByIDQuery(int id)
        {
            Id = id;
        }
    }
}
