using ProductProject.Domain.Data;
using ProductProject.Domain.Interface;
using ProductProject.Models.Dtos;
using ProductProject.Models.Entities;
using ProductProject.Services.Interface;

namespace ProductProject.Services.Business
{
    public class ProductService : IproductService

    {
        private readonly IProductRepository<Product> _ProductRepository;
        public ProductService(ProductRepository<Product> productRepository)
        {
            _ProductRepository = productRepository;
        }

        public IQueryable<Product> GetProductDetails()
        {
            var products = _ProductRepository.GetAll();
            return products;
        }

        public async Task<ResponseDto> CreateProductData(ProductDto prodcutDto)
        {
            var responseDto = new ResponseDto();
            var details = _ProductRepository.GetAll().Where(x => x.Id == prodcutDto.Id).FirstOrDefault();
            if (details == null)
            {
                var ProductDetails = new Product
                {
                    Id = prodcutDto.Id,
                    Name = prodcutDto.Name,
                    Description = prodcutDto.Description,
                   
                };
                _ProductRepository.Create(ProductDetails);
                _ProductRepository.SaveChanges();

                responseDto.Retval = 0;
                responseDto.RetMsg = "Successfully added";
            }
            else
            {
                responseDto.Retval = 1;
                responseDto.RetMsg = "User already Exist";
            }

            return responseDto;

        }

        public async Task<ResponseDto> UpdateProduct(Guid Id, ProductDto prodcutDto)
        {
            var responseDto = new ResponseDto();
            var product = _ProductRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
            if (product != null)
            {
                product.Id = prodcutDto.Id;
                product.Name = prodcutDto.Name;
                product.Description = prodcutDto.Description;

                _ProductRepository.Update(product);
                _ProductRepository.SaveChanges();

                responseDto.Retval = 0;
                responseDto.RetMsg = "Updated Successfully";
            }
            else
            {
                responseDto.Retval = 1;
                responseDto.RetMsg = "User does not exists";
            }



            return responseDto;

        }

        public async Task<ResponseDto> DeleteProduct(Guid Id)
        {
            var responseDto = new ResponseDto();
            var product = _ProductRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
            if (product != null)
            {
                _ProductRepository.Delete(product);
                _ProductRepository.SaveChanges();

                responseDto.Retval = 0;
                responseDto.RetMsg = "Successfully deleted";
            }
            else
            {
                responseDto.Retval = 1;
                responseDto.RetMsg = "Cannot find";

            }
            return responseDto;
        }
    }
}

