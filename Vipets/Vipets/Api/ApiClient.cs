using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api.Models;

namespace Vipets.Api
{
    public class ApiClient : IApiClient
    {
        public ApiClient(string apiUrlBase)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
            {
                throw new ArgumentNullException("apiUrlBase", "Uma url base de API deve ser informada");
            }

            AppContext.SetSwitch("System.Net.Http.useSocketsHttpHandler", false);

            _apiUrlBase = apiUrlBase;
        }

        private HttpClient _restClient;
        private string _apiUrlBase;

        public async Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await GetAsync(apiRoute);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();

            var response = await _restClient.GetAsync(_restClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        public async Task<BaseApiResult<TModel>> PostAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await PostAsync(apiRoute, body);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);
                callback?.Invoke(result);
                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        public async Task<BaseApiResult<TModel>> PostResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var data = await PostAsync(apiRoute, body);
                var result = JsonConvert.DeserializeObject<OkApiResult<TModel>>(data, GetConverter());
                callback?.Invoke(result);
                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> PostAsync(string apiRoute, object body)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();

            var bodySerialize = JsonConvert.SerializeObject(body);
            StringContent content = new StringContent(bodySerialize, Encoding.UTF8, "application/json");
            var response = await _restClient.PostAsync(_restClient.BaseAddress, content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var finalRequestUri = response.RequestMessage.RequestUri;
                if (finalRequestUri != _restClient.BaseAddress)
                {
                    if (IsHostTrusted(finalRequestUri))
                    {
                        response = await _restClient.PostAsync(finalRequestUri, content);
                    }
                }
            }

            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            return data;
        }

        public async Task<BaseApiResult<TModel>> PutAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await PutAsync(apiRoute, body);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);
                callback?.Invoke(result);
                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        public async Task<BaseApiResult<TModel>> PutResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var data = await PutAsync(apiRoute, body);
                var result = JsonConvert.DeserializeObject<OkApiResult<TModel>>(data, GetConverter());
                callback?.Invoke(result);
                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> PutAsync(string apiRoute, object body)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();

            var bodySerialize = JsonConvert.SerializeObject(body);
            StringContent content = new StringContent(bodySerialize, Encoding.UTF8, "application/json");
            var response = await _restClient.PutAsync(_restClient.BaseAddress, content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var finalRequestUri = response.RequestMessage.RequestUri;
                if (finalRequestUri != _restClient.BaseAddress)
                {
                    if (IsHostTrusted(finalRequestUri))
                    {
                        response = await _restClient.PutAsync(finalRequestUri, content);
                    }
                }
            }

            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            return data;
        }

        private bool IsHostTrusted(Uri uri)
        {
            return (uri.Host == _restClient.BaseAddress.AbsoluteUri);
        }

        private IsoDateTimeConverter GetConverter()
        {
            return new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };
        }

        public IApiClient UseSufix(string urlSufix)
        {
            if (!_apiUrlBase.EndsWith(urlSufix))
            {
                _apiUrlBase = _apiUrlBase + "/" + urlSufix;
            }

            return this;
        }

        private void ClearReponseHeaders()
        {
            _restClient.DefaultRequestHeaders.Clear();
        }

        public void Dispose()
        {

        }
    }
}