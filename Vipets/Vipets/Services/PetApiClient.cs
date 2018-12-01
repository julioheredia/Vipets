using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class PetApiClient : ApiClient, IPetApiClient
    {
        public PetApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<List<Pet>>> PetsByPetshop(long petshopId) 
        {
            StringBuilder content = new StringBuilder();
            content.Append("pets/petshop").Append("?").Append("petshopId=").Append(petshopId);
            return await GetAsync<List<Pet>>(content.ToString());
        }

    }
}
