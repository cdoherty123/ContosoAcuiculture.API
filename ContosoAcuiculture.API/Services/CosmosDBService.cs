using ContosoAcuiculture.API.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoAcuiculture.API.Services
{
    public class CosmosDBService : ICosmosDBService
    {
        private static Container _container;

        public CosmosDBService(CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<bool> AddAsync(ContosoAcuicultureModel parcel)
        {
            try
            {
                var req = await _container.CreateItemAsync<ContosoAcuicultureModel>(parcel);

                if (req.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }

                return false;

            }
            catch (CosmosException ex)
            {

                return false;
            }
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<ContosoAcuicultureModel>(id, new PartitionKey(id));
        }

        public async Task<ContosoAcuicultureModel> GetAsync(string id)
        {
            try
            {
                Console.WriteLine(id);

                ItemResponse<ContosoAcuicultureModel> response = await _container.ReadItemAsync<ContosoAcuicultureModel>(id, new PartitionKey(id));

                Console.WriteLine(response);

                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContosoAcuicultureModel>> GetAllAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<ContosoAcuicultureModel>(new QueryDefinition(queryString));

            List<ContosoAcuicultureModel> results = new List<ContosoAcuicultureModel>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<ContosoAcuicultureModel> UpdateAsync(ContosoAcuicultureModel entity)
        {
            try
            {
                Console.WriteLine(entity);
                var ContosoAcuicultureModel = await GetAsync(entity.ID.ToString());
                if (ContosoAcuicultureModel != null)
                {
                    return await _container.UpsertItemAsync<ContosoAcuicultureModel>(entity, new PartitionKey(entity.ID));
                }

                return null;
            }
            catch (CosmosException ex)
            {

                throw;
            }
        }
    }
}