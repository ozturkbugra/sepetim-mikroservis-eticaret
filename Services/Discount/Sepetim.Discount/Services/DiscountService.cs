using Dapper;
using Sepetim.Discount.Context;
using Sepetim.Discount.Dtos;

namespace Sepetim.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@Code", createCouponDto.Code);
            parameters.Add("@Rate", createCouponDto.rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponID = @CouponID";

            var parameters = new DynamicParameters();

            parameters.Add("@CouponID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
           string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }

        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@Rate", updateCouponDto.rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponID", updateCouponDto.CouponID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
