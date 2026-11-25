namespace Sepetim.Discount.Dtos
{
    public class UpdateCouponDto
    {
        public int CouponID { get; set; }

        public string Code { get; set; }

        public int rate { get; set; }

        public bool IsActive { get; set; }

        public DateTime ValidDate { get; set; }
    }
}
