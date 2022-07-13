using CatalogService.Api.Dtos;
using CatalogService.Api.Models;
using UdemyMicroservices.Common.Dtos;

namespace CatalogService.Api.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
