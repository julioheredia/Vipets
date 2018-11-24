using System.Collections.Generic;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public interface IActivityApiClient : IApiClient
    {
        Task<BaseApiResult<List<Activity>>> Activitys();
    }
}
