using Sepetim.Catalog.Dtos.ProductImageDtos;

namespace Sepetim.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);

        Task DeleteProductImageAsync(string id);

        Task<ResultProductImageDto> GetProductImageByIdAsync(string id);
    }
}
