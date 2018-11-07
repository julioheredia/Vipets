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
        public PetActivityApiClient() : base("http://179.220.227.97:8080/vipets-mypet-server/") { }

        public async Task<BaseApiResult<List<PetActivity>>> SearchPetActivityByUser(User user)
        {
            return await FslApiClient.Current.PostAsync<List<PetActivity>>("searchPetActivityByUser", user);
        }

    }
}
