using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sepetim.Catalog.Dtos.ProductDetailDtos;
using Sepetim.Catalog.Services.ProductDetailServices;

namespace Sepetim.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetailGetById(string id)
        {
            var value = await _ProductDetailService.GetProductDetailByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDetailAdd(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayı başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> ProductDetailUpdate(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDetailDelete(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayı başarıyla silindi.");
        }
    }
}
