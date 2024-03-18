using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using PetShop.BusinessObject.Models;
using PetShop.Repositories.Interfaces;
using PetShop.Services.Enums;

namespace PetShop.GRPC.Services
{
    public class CategoryService : CategoryServices.CategoryServicesBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override Task<CategoryResponse> CreateCategory(CreateCategoryRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var categoryItem = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name, 
                Description = request.Description, 
                Status = CategoryStatus.Available.ToString(),
            };
            _categoryRepository.Create(categoryItem);
            return Task.FromResult(new CategoryResponse
            {
                Id = categoryItem.Id.ToString(),
                Name = categoryItem.Name,
                Description = categoryItem.Description,
                Status = categoryItem.Status,
            });
        }

        public override Task<CategoryResponse> UpdateCategory(UpdateCategoryRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var category = _categoryRepository.Get(request.Id);
            if (category == null)
            {
                throw new Exception("Cannot find this category");
            } else
            {
                category.Description = request.Description;
                category.Name = request.Name;
                category.Status = CategoryStatus.Available.ToString();
            }
            _categoryRepository.Update(category);
            return Task.FromResult(new CategoryResponse
            {
                Id = category.Id.ToString()
            });
        }

        public override Task<CategoryResponse> DeleteCategory(DeleteCategoryRequest request, ServerCallContext context)
        {
            if(request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            }
            var category = _categoryRepository.Get(request.Id);
            if(category == null)
            {
                throw new Exception("Cannot find this category");
            } else
            {
                _categoryRepository.Delete(category);
            }
            return base.DeleteCategory(request, context);
        }

        public override Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error request"));
            } 
            var response = new GetAllCategoriesResponse();
            var categories = _categoryRepository.Get().Where(x => x.Status == CategoryStatus.Available.ToString());
            foreach ( var category in categories)
            {
                response.Category.Add(new CategoryResponse
                {
                    Id = category.Id.ToString(),
                    Name = category.Name,
                    Description = category.Description,
                    Status = category.Status,
                });
            }
            return Task.FromResult(response);
        }
    }
}
