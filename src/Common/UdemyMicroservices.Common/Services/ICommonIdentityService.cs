using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyMicroservices.Common.Services
{
    public interface ICommonIdentityService
    {
        public string GetUserId { get; }
    }
}
