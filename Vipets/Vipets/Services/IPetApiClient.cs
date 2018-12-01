using System.Collections.Generic;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public interface IPetApiClient : IApiClient
    {
        Task<BaseApiResult<List<Pet>>> PetsByPetshop(long petshopId);
    }
}
