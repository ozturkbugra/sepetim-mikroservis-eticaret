using Microsoft.AspNetCore.Mvc;
using Sepetim.Catalog.Dtos.ProductImageDtos;
using Sepetim.Catalog.Services.ProductImageServices;

namespace Sepetim.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductImageGetById(string id)
        {
            var value = await _ProductImageService.GetProductImageByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> ProductImageAdd(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Resmi başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> ProductImageUpdate(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Resmi başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductImageDelete(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Resmi başarıyla silindi.");
        }
    }
}
