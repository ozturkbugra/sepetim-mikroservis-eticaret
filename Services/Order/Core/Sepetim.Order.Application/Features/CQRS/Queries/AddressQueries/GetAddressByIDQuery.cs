namespace Sepetim.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIDQuery
    {
        public int Id { get; set; }

        public GetAddressByIDQuery(int id)
        {
            Id = id;
        }
    }
}
