using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Common.ControllerBases;
using UdemyMicroservices.Common.Dtos;

namespace FakePaymentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance<NoContent>(Response<NoContent>.Success(200));
        }
    }
}
