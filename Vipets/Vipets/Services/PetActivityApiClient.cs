using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class PetActivityApiClient : ApiClient, IPetActivityApiClient
    {
        public PetActivityApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<List<PetActivity>>> PetActivitysByUser(long userId)
        {
            StringBuilder content = new StringBuilder();
            content.Append("petActivitys/user").Append("?").Append("patshopId=").Append(userId);
            return await FslApiClient.Current.GetAsync<List<PetActivity>>(content.ToString());
        }

        public async Task<BaseApiResult<List<PetActivity>>> PetActivitysByPetshop(long petshopId)
        {
            StringBuilder content = new StringBuilder();
            content.Append("petActivitys/petshop").Append("?").Append("petshopId=").Append(petshopId);
            return await FslApiClient.Current.GetAsync<List<PetActivity>>(content.ToString());
        }

        
    }
}
