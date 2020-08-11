using System;
using System.Threading;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using Microsoft.Extensions.Hosting;

namespace docker.worker
{
    public class WorkerService : IHostedService
    {
        private const int SleepDurationInMilliSeconds = 3000;
        private readonly IUserService userService;

        /// <summary>
        ///     Initializes the class of type <see cref="WorkerService"/>.
        /// </summary>
        public WorkerService(
            IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        ///     Starts the worker service in thread safe manner.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel the service run.</param>
        /// <returns></returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var users = await this.userService.GetUsers().ConfigureAwait(false);

            foreach(var user in users)
            {
                Console.WriteLine(user.Id + "/t" + user.Name + "/t" + user.Email + "/t" + user.Phone);
                Thread.Sleep(SleepDurationInMilliSeconds);
            }
        }

        /// <summary>
        ///     Stops the worker service in thread safe manner.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>Task.WhenAll().Dispose());
        }
    }
}
