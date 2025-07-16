using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Models.Dtos;
using ProductProject.Services.Business;
using ProductProject.Services.Interface;

namespace ProductProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IproductService _productService;

        public ProductController(IproductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductDetails")]
        public async Task<IActionResult> GetProductDetails()
        {
            var response = _productService.GetProductDetails();
            return Ok(response);
        }

        [HttpPost("CreateStudentDetails")]
        public async Task<IActionResult> CreateProductDetails(ProductDto productDto)
        {
            var response = _productService.CreateProductData(productDto);
            return Ok(response);
        }

        [HttpPut("UpdateStudent/{Id}")]
        public async Task<IActionResult> UpdateProduct(Guid Id, ProductDto productDto)
        {
            var response = _productService.UpdateProduct(Id, productDto);
            return Ok(response);
        }

        [HttpDelete("DeleteStudent/{Id}")]
        public async Task<IActionResult> DeleteStudent(Guid Id)
        {
            var response = _productService.DeleteProduct(Id);
            return Ok(response);
        }
    }
}
    

