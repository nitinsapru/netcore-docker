using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using docker.worker.manager.SharedModel.CovidService;
using Newtonsoft.Json;

namespace docker.worker.manager.Implementations
{
    public class CovidServiceClient : HttpClientProvider, ICovidService
    {
        private readonly string covidPatientApi;

        /// <summary>
        ///     Initializes the class of type <see cref="CovidServiceClient"/>.
        /// </summary>
        public CovidServiceClient(
            IHttpClientFactory httpClientFactory):
            base(httpClientFactory)
        {
            this.covidPatientApi = "https://api.covid19india.org/raw_data{0}.json";
        }

        ///<inheritdoc/>
        public async Task<IList<Patient>> GetPatientsInfo()
        {
            var indexer = 0;
            CovidData patientData = null;
            var patientsData = new List<Patient>();

            do
            {
                indexer = indexer + 1;

                Console.WriteLine($"Getting data for API index sequence {indexer}.");

                var data = await this.GetDataFromApi(string.Format(this.covidPatientApi, indexer)).ConfigureAwait(false);

                if (data != default)
                {
                    patientData = JsonConvert.DeserializeObject<CovidData>(data);

                    if (patientData.raw_data.Any())
                    {
                        patientsData.AddRange(patientData.raw_data);
                    }
                }

                if(data == default)
                {
                    patientData = default;
                }
            }
            while (patientData != null);

            Console.WriteLine($"Received {patientsData.Count} patient records from source API {this.covidPatientApi}");

            return patientsData;
        }
    }
}
