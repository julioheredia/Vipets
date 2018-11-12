using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public interface IAuthenticationApiClient : IApiClient
    {
        Task<BaseApiResult<User>> Authentication(string email, string password);
    }
}
