using Sepetim.Catalog.Dtos.ProductDetailDtos;

namespace Sepetim.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsync(string id);

        Task<ResultProductDetailDto> GetProductDetailByIdAsync(string id);
    }
}
