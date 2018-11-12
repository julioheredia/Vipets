using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;

namespace Vipets.Services
{
    class ImagesApiClient : ApiClient, IImagesApiClient
    {
        public ImagesApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<byte[]>> GetImage(string id)
        {
            return await FslApiClient.Current.GetAsync<byte[]>("images/" + id + ".jpeg");
        }
    }
}
