using ProductProject.Models.Dtos;
using ProductProject.Models.Entities;

namespace ProductProject.Services.Interface
{
        public interface IproductService 
        {
            public IQueryable<Product> GetProductDetails();
            public Task<ResponseDto> CreateProductData(ProductDto prodcutDto);

            public Task<ResponseDto> UpdateProduct(Guid Id, ProductDto prodcut);
            public Task<ResponseDto> DeleteProduct(Guid Id);
        }
 }
