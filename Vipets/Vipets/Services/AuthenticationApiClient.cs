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
            Credentials credentials = new Credentials(email, password, "");
            return await FslApiClient.Current.PostAsync<User>("authentication", credentials);

            // string content = String.Format("login?Email={0}&Password={1}", Email, Password); // Get login
            //return await FslApiClient.Current.GetAsync<User>(content);
        }

    }
}
