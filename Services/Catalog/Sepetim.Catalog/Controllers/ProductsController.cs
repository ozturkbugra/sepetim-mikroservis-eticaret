using Microsoft.AspNetCore.Mvc;
using Sepetim.Catalog.Dtos.ProductDtos;
using Sepetim.Catalog.Services.ProductServices;

namespace Sepetim.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _ProductService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductGetById(string id)
        {
            var value = await _ProductService.GetProductByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(CreateProductDto createProductDto)
        {
            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> ProductUpdate(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDelete(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }
    }
}
