using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api.Models;

namespace Vipets.Api
{
    public interface IApiClient : IDisposable
    {
        Task<BaseApiResult<T>> GetAsync<T>(string apiRoute, Action<BaseApiResult<T>> callback = null);
        IApiClient UseSufix(string urlSufix);
        Task<BaseApiResult<TModel>> PostResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null);
        Task<BaseApiResult<TModel>> PostAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null);
        Task<BaseApiResult<TModel>> PutResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null);
        Task<BaseApiResult<TModel>> PutAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null);
    }
}
