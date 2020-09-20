using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using web_api.Config.Database;
using web_api.Models.Base;

namespace web_api.Repositories.Abstractions
{
    public class RepositoryBase<ClassType> where ClassType : EntityBase
    {
        protected IMongoCollection<ClassType> Context { get; private set; }
        public RepositoryBase(IDatabaseSettings settings, string collectionName)
        {
            this.Context = settings.Database.GetCollection<ClassType>(collectionName);
        }

        protected async Task<ClassType> GenericFinderWithFilterDefinition(FilterDefinition<ClassType> filter)
        {
            return await Context.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        protected async IAsyncEnumerable<ClassType> GenericEnumerableFinderWithFilterDefinition(FilterDefinition<ClassType> filter)
        {
            foreach (ClassType entityType in await Context.FindAsync(filter).Result.ToListAsync())
            {
                yield return entityType;
            }
        }
    }
}