using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using docker.worker.manager.Contracts;
using docker.worker.manager.SharedModel.CovidService;
using MongoDB;
using MongoDB.Contracts;
using MongoDB.Driver;
using MongoDB.Exceptions;

namespace docker.worker.manager.Implementations
{
    public class CovidStoreProvider : ICovidStore
    {
        private const string CollectionName = "patients";
        private const string DatabaseName = "covidstore";
        private readonly IMongoDbClient mongoDbClient;

        /// <summary>
        ///     Initializes the class of type <see cref="CovidStoreProvider"/>.
        /// </summary>
        public CovidStoreProvider()
        {
            this.mongoDbClient = new MongoDbClient($"mongodb+srv://genie:JEaqMq3H8yTvcCxk@cluster0.bh6s6.gcp.mongodb.net/{DatabaseName}?retryWrites=true&w=majority");
        }

        public async Task<IList<Patient>> AddorReplacePatients(IList<Patient> patients)
        {
            var mongoCollection = await this.GetMongoDbCollection<Patient>().ConfigureAwait(false);

            try
            {
                var affectedRows = await this.mongoDbClient.AddDocumentsToCollection<Patient>(
                    mongoCollection, patients.ToList()).ConfigureAwait(false);

                Console.WriteLine($"Added {affectedRows} documents into the collection {CollectionName}");

                return patients;
            }
            catch (MongoDbClientException)
            {
                throw;
            }
        }

        private async Task<IMongoCollection<T>> GetMongoDbCollection<T>()
        {
            return await this.mongoDbClient.CreateCollectionIfNotExists<T>(DatabaseName, CollectionName).ConfigureAwait(false);
        }
    }
}
