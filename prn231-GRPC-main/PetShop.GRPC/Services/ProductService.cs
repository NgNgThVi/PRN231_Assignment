using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using PetShop.BusinessObject.Models;
using PetShop.Repositories.Implements;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;

namespace PetShop.GRPC.Services
{
    public class ProductService : ProductServices.ProductServicesBase
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override Task<ProductResponse> CreateProduct(CreateProductRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var productItems = new Product{
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Status = request.Status,               
            };
            _productRepository.Create(productItems);
            return Task.FromResult(new ProductResponse
            {
                Id = productItems.Id.ToString(),
                Name = productItems.Name,
                Price = (int)productItems.Price,
                Status = productItems.Status,
            });
        }

        public override Task<GetAllProductsResponse> GetAllProducts(GetAllProductsRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var response = new GetAllProductsResponse();
            var products = _productRepository.Get().ToList();
            foreach (var product in products)
            {
                response.Product.Add(new ProductResponse 
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    Price= (int)product.Price,
                    Status = product.Status,
                    CategoryId = product.CategoryId.ToString()
                });
            }
            return Task.FromResult(response);
        }

        public override Task<ProductResponse> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            Guid? categoryId = null;
            if (!string.IsNullOrEmpty(request.CategoryId) && Guid.TryParse(request.CategoryId, out Guid parsedId))
            {
                categoryId = parsedId;
            }
            var product = _productRepository.Get(request.Id);
            if (product == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Cannot find this product or product does not exist"));
            } 
            else
            {
                product.Name = request.Name;
                product.Price = request.Price;
                product.Status = request.Status;
                product.CategoryId = categoryId;
            }
            _productRepository.Update(product);
            return Task.FromResult(new ProductResponse
            {
                Id = product.Id.ToString()
            });
        }

        public override Task<ProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var product = _productRepository.Get(request.Id);
            if(product == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Cannot find this product or product does not exist"));
            }
            _productRepository.Delete(product);
            return base.DeleteProduct(request, context);
        }
    }
}