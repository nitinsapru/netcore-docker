using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using docker.worker.manager.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace docker.worker
{
    class Program
    {
        static async Task Main()
        {
            var hostService = new HostBuilder();

            hostService.ConfigureServices((context, builder) =>
            {
                builder.AddHttpClient();
                builder.AddSingleton<IUserService, UserClient>();
                builder.AddSingleton<ICovidService, CovidServiceClient>();
                builder.AddHostedService<CovidWorkerService>();
            });

            using (var buildHostService = hostService.Build())
            {
                await buildHostService.RunAsync().ConfigureAwait(true);
                await buildHostService.StopAsync().ConfigureAwait(true);
            }
        }
    }
}
