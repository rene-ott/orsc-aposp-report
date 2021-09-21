using System.Collections.Generic;
using System.Threading.Tasks;
using ApospReport.Domain.Contracts;
using ApospReport.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ApospReport.Domain.Services
{
    public interface IItemDefinitionService
    {
        Task<IList<ItemDefinition>> GetAll();
    }

    internal class ItemDefinitionService : IItemDefinitionService
    {
        private readonly IGenericRepository genericRepository;
        private readonly IMemoryCache cache;
        private const string ItemDefinitionsCacheKey = nameof(ItemDefinitionsCacheKey);

        public ItemDefinitionService(IGenericRepository genericRepository, IMemoryCache cache)
        {
            this.genericRepository = genericRepository;
            this.cache = cache;
        }

        public async Task<IList<ItemDefinition>> GetAll()
        {
            if (!cache.TryGetValue<IList<ItemDefinition>>(ItemDefinitionsCacheKey, out var value))
                return value;

            var itemDefinitions = await genericRepository.GetItemDefinitions();
            return cache.Set(ItemDefinitionsCacheKey, itemDefinitions);
        }
    }
}
