using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Services.Models;

namespace Vipets.Services
{
    class LoginApiClient : ApiClient, ILoginApiClient
    {
        public LoginApiClient() : base("http://192.168.56.1:8080/") { }

        public async Task<BaseApiResult<User>> Login(string email, string password)
        {
            //return await FslApiClient.Current.GetAsync<User>("login");
            return await FslApiClient.Current.PostAsync<User>("login");
        }
    }
}
