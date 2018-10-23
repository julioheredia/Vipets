using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Services.Models;

namespace Vipets.Services
{
    public interface ILoginApiClient : IApiClient
    {
        Task<BaseApiResult<User>> Login(string email, string password);
    }
}
