using System.Collections.Generic;
using System.Threading.Tasks;
using docker.worker.manager.SharedModel.CovidService;

namespace docker.worker.manager.Contracts
{
    public interface ICovidStore
    {
        /// <summary>
        ///     Adds or replaces the existing documents in bulk manner in Mongo storage.
        /// </summary>
        /// <param name="patients">The list of patients.</param>
        /// <returns>The list of patients that are added to the storage.</returns>
        Task<IList<Patient>> AddorReplacePatients(IList<Patient> patients);
    }
}
