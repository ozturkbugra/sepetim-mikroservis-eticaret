using Sepetim.Catalog.Dtos.ProductDtos;

namespace Sepetim.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);

        Task<ResultProductDto> GetProductByIdAsync(string id);
    }
}
