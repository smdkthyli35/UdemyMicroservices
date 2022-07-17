using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UdemyMicroservices.Common.Services
{
    public class CommonIdentityService : ICommonIdentityService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CommonIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
