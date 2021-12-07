using ContosoAcuiculture.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoAcuiculture.API.Services
{
    public interface ICosmosDBService
    {
        Task<bool> AddAsync(ContosoAcuicultureModel parcel);
        Task DeleteAsync(string id);
        Task<IEnumerable<ContosoAcuicultureModel>> GetAllAsync(string queryString);
        Task<ContosoAcuicultureModel> GetAsync(string id);
        Task<ContosoAcuicultureModel> UpdateAsync(ContosoAcuicultureModel parcel);
    }
}