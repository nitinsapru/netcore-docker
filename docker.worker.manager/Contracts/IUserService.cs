using System.Collections.Generic;
using System.Threading.Tasks;
using docker.worker.manager.SharedModel.UserService;

namespace docker.worker.manager.Contracts
{
    public interface IUserService
    {
        /// <summary>
        ///     Gets the list of users in an async manner.
        /// </summary>
        /// <returns></returns>
        Task<IList<User>> GetUsers();
    }
}
