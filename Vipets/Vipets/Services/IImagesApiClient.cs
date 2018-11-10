using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;

namespace Vipets.Services
{
    interface IImagesApiClient : IApiClient
    {
        Task<BaseApiResult<byte[]>> GetImage(string id);
    }
}
