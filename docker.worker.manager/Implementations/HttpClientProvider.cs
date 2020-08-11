using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace docker.worker.manager.Implementations
{
    public abstract class HttpClientProvider
    {
        protected readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        ///     Initializes the class of type <see cref="HttpClientProvider"/>.
        /// </summary>
        protected HttpClientProvider(
            IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        protected async Task<string> GetDataFromApi(string endpoint)
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync(endpoint).ConfigureAwait(false);

                    if (!response.IsSuccessStatusCode)
                    {
                        return default;
                    }

                    return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
