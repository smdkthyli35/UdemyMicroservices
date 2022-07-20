using MediatR;
using OrderService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMicroservices.Common.Dtos;

namespace OrderService.Application.Features.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
