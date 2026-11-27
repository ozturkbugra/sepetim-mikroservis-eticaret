namespace Sepetim.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class UpdateAddressCommand
    {
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
