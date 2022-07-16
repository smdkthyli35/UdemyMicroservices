using BasketService.Api.Dtos;
using UdemyMicroservices.Common.Dtos;

namespace BasketService.Api.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
