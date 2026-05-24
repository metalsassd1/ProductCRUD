using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.DTOs;
using ProductCRUD.Services;

namespace ProductCRUD.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var products = await _productService.GetAllAsync(search, page, pageSize);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateUpdateDto dto)
        {
            var result = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductCreateUpdateDto dto)
        {
            var success = await _productService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpPost("deleteList")]
        public async Task<IActionResult> DeleteList([FromBody] ProductDeleteDto dto)
        {
            if (dto == null || dto.Ids == null || !dto.Ids.Any())
            {
                return BadRequest(new { message = "กรุณาระบุ ID สินค้าที่ต้องการลบ" });
            }

            var success = await _productService.DeleteListAsync(dto.Ids);

            return success
                ? NoContent()
                : NotFound(
                    new { message = "ไม่พบสินค้าตาม ID ที่ระบุ หรือสินค้าถูกลบไปก่อนหน้านี้แล้ว" }
                );
        }
    }
}
