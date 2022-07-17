using BasketService.Api.Dtos;
using BasketService.Api.Services;
using BasketService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Common.ControllerBases;
using UdemyMicroservices.Common.Services;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ICommonIdentityService _commonIdentityService;

        public BasketsController(IBasketService basketService, ICommonIdentityService commonIdentityService)
        {
            _basketService = basketService;
            _commonIdentityService = commonIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_commonIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete(_commonIdentityService.GetUserId));
        }
    }
}
