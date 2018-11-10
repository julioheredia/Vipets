using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;

namespace Vipets.Services
{
    class ImagesApiClient : ApiClient, IImagesApiClient
    {
        public ImagesApiClient() : base("http://179.220.227.97:8080/vipets-mypet-server/images/") { }

        public async Task<BaseApiResult<byte[]>> GetImage(string id)
        {
            return await FslApiClient.Current.GetAsync<byte[]>(id + ".jpeg");
        }
    }
}
