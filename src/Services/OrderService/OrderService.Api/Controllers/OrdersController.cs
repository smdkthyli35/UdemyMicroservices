using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Dtos;
using OrderService.Application.Features.Commands.CreateOrder;
using OrderService.Application.Features.Queries.GetOrdersByUserId;
using UdemyMicroservices.Common.ControllerBases;
using UdemyMicroservices.Common.Dtos;
using UdemyMicroservices.Common.Services;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ICommonIdentityService _commonIdentityService;

        public OrdersController(IMediator mediator, ICommonIdentityService commonIdentityService)
        {
            _mediator = mediator;
            _commonIdentityService = commonIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            Response<List<OrderDto>> response = await _mediator.Send(new GetOrdersByUserIdQuery { UserId = _commonIdentityService.GetUserId });
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            Response<CreatedOrderDto> response = await _mediator.Send(createOrderCommand);
            return CreateActionResultInstance(response);
        }
    }
}
