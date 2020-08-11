using System.Collections.Generic;
using System.Threading.Tasks;
using docker.worker.manager.SharedModel.CovidService;

namespace docker.worker.manager.Contracts
{
    public interface ICovidService
    {
        /// <summary>
        ///     Gets the patient data from the https://api.covid19india.org/ services.
        /// </summary>
        /// <returns>The list of patient information.</returns>
        Task<IList<Patient>> GetPatientsInfo();
    }
}
