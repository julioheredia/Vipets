using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vipets.Api;
using Vipets.Api.Models;
using Vipets.Models;

namespace Vipets.Services
{
    public class UserApiClient : ApiClient, IUserApiClient
    {
        public UserApiClient() : base(Vipets.Resources.Application.restUrl) { }

        public async Task<BaseApiResult<List<User>>> EmployeesByPetshop(long petshopId)
        {
            StringBuilder content = new StringBuilder();
            content.Append("users/employees/petshop").Append("?").Append("petshopId=").Append(petshopId);
            return await GetAsync<List<User>>(content.ToString());
        }

        public async Task<BaseApiResult<List<User>>> ClientsByPetshop(long petshopId)
        {
            StringBuilder content = new StringBuilder();
            content.Append("users/clients/petshop").Append("?").Append("petshopId=").Append(petshopId);
            return await GetAsync<List<User>>(content.ToString());
        }

        public async Task<BaseApiResult<User>> SaveClient(User client)
        {
            return await PutAsync<User>("/users/clients", client);
        }

        public async Task<BaseApiResult<User>> SaveEmployee(User client)
        {
            return await PutAsync<User>("/users/employees", client);
        }

    }
}
