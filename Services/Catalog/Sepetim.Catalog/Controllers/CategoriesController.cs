using Microsoft.AspNetCore.Mvc;
using Sepetim.Catalog.Dtos.CategoryDtos;
using Sepetim.Catalog.Services.CategoryServices;

namespace Sepetim.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryGetById(string id)
        {
            var value = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CategoryDelete(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi.");
        }
    }
}
