using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sepetim.Discount.Entities;
using System.Data;

namespace Sepetim.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Bugra;Database=SepetimDiscountDB;User Id=bugra;Password=123;TrustServerCertificate=True;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
