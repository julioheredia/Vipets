using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class AuthenticationApiClient : ApiClient, IAuthenticationApiClient
    {
        public AuthenticationApiClient() : base(Vipets.Resources.Application.restUrl) { }
        
        public async Task<BaseApiResult<User>> Authentication(string email, string password)
        {
            return await PostAsync<User>("authentication", new Credentials() { email = email, password = password, token = "" });
        }

    }
}
