using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using docker.worker.manager.SharedModel.UserService;
using Newtonsoft.Json;

namespace docker.worker.manager.Implementations
{
    public class UserClient : HttpClientProvider, IUserService
    {
        private readonly string userApiEndpoint;

        /// <summary>
        ///     Initializes the class of type <see cref="UserClient"/>.
        /// </summary>
        public UserClient(
            IHttpClientFactory httpClientFactory):
            base(httpClientFactory)
        {
            this.userApiEndpoint = "https://jsonplaceholder.typicode.com/users";
        }

        ///<inheritdoc/>
        public async Task<IList<User>> GetUsers()
        {
            var response = await this.GetDataFromApi(this.userApiEndpoint).ConfigureAwait(false);

            if(string.IsNullOrEmpty(response))
            {
                // THROW;
            }

            return JsonConvert.DeserializeObject<IList<User>>(response);
        }
    }
}
