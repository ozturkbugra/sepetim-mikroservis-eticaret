using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
