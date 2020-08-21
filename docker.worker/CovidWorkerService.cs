using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using Microsoft.Extensions.Hosting;

namespace docker.worker
{
    public class CovidWorkerService : IHostedService
    {
        private readonly ICovidService covidService;
        private readonly ICovidStore covidStore;

        /// <summary>
        ///     Initialize the class of type <see cref="CovidWorkerService"/>.
        /// </summary>
        public CovidWorkerService(
            ICovidService covidService,
            ICovidStore covidStore)
        {
            this.covidService = covidService;
            this.covidStore = covidStore;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var patientsInfo = await this.covidService.GetPatientsInfo().ConfigureAwait(false);

            if(patientsInfo.Any())
            {
                await this.covidStore.AddorReplacePatients(patientsInfo).ConfigureAwait(false);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            GC.Collect();
            return Task.CompletedTask;
        }
    }
}
