using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public interface IPetActivityApiClient : IApiClient
    {
        Task<BaseApiResult<List<PetActivity>>> PetActivitysByEmployee(long userId);
        Task<BaseApiResult<List<PetActivity>>> PetActivitysByPetshop(long petshopId);
        Task<BaseApiResult<PetActivity>> SavePetActivitys(PetActivity petActivity);
    }
}
