using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public interface IUserApiClient : IApiClient
    {
        Task<BaseApiResult<List<User>>> EmployeesByPetshop(long petshopId);
        Task<BaseApiResult<List<User>>> clientsByPetshop(long petshopId);
        Task<BaseApiResult<User>> CreateClient(User client);
        Task<BaseApiResult<User>> CreateEmployee(User client);
    }
}
