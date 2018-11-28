using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class BreedApiClient : ApiClient, IBreedApiClient
    {
        public BreedApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<List<Breed>>> breeds()
        {
            StringBuilder content = new StringBuilder();
            content.Append("breeds");
            return await GetAsync<List<Breed>>(content.ToString());
        }
    }
}
