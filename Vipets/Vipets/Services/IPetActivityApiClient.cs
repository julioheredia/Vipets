using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Services.Models;

namespace Vipets.Services
{
    public interface IPetActivityApiClient : IApiClient
    {
        Task<BaseApiResult<List<PetActivity>>> SearchPetActivityByUser(User user);
    }
}
