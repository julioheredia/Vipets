using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Services.Models;

namespace Vipets.Services
{
    public class PetActivityApiClient : ApiClient, IPetActivityApiClient
    {
        public PetActivityApiClient() : base("http://192.168.56.1:8080/") { }

        public async Task<BaseApiResult<List<PetActivity>>> SearchPetActivityByUser(User user)
        {
            return await FslApiClient.Current.PostAsync<List<PetActivity>>("searchPetActivityByUser");
        }

    }
}
