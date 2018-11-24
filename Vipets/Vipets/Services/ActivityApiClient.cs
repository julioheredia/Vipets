using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class ActivityApiClient : ApiClient, IActivityApiClient
    {
        public ActivityApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<List<Activity>>> Activitys()
        {
            StringBuilder content = new StringBuilder();
            content.Append("activitys");
            return await GetAsync<List<Activity>>(content.ToString());
        }
    }
}
