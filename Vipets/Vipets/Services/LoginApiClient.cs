using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Services.Models;

namespace Vipets.Services
{
    public class LoginApiClient : ApiClient, ILoginApiClient
    {
        public LoginApiClient() : base("http://179.220.227.97:8080/vipets-mypet-server/") { }
        
        public async Task<BaseApiResult<User>> Login(string email, string password)
        {
            Credentials credentials = new Credentials(email, password, "");
            return await FslApiClient.Current.PostAsync<User>("login", credentials);

            // string content = String.Format("login?email={0}&password={1}", email, password); // Get login
            //return await FslApiClient.Current.GetAsync<User>(content);
        }

    }
}
