using System;
using System.Threading;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using Microsoft.Extensions.Hosting;

namespace docker.worker
{
    public class CovidWorkerService : IHostedService
    {
        private readonly ICovidService covidService;

        /// <summary>
        ///     Initialize the class of type <see cref="CovidWorkerService"/>.
        /// </summary>
        public CovidWorkerService(
            ICovidService covidService)
        {
            this.covidService = covidService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this.covidService.GetPatientsInfo().ConfigureAwait(false);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
