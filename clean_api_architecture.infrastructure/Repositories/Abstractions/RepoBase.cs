using System.Collections.Generic;
using System.Threading.Tasks;
using clean_api_architecture.shared.Abstractions;
using clean_api_architecture.infrastructure.Config.Database;
using MongoDB.Driver;

namespace clean_api_architecture.infrastructure.Repositories.Abstractions
{
    public class RepoBase<ClassType> where ClassType : EntityBase
    {
        protected IMongoCollection<ClassType> Context { get; private set; }
        public RepoBase(IDatabaseSettings settings, string collectionName)
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