using System.Collections.Generic;
using System.Threading.Tasks;
using clean_api_architecture.shared.Abstractions;

namespace clean_api_architecture.infrastructure.Repositories.Abstractions
{
    public interface IRepository<ClassType> where ClassType : EntityBase
    {
        IAsyncEnumerable<ClassType> FindAll();
        Task<ClassType> FindById(string id);
        Task<ClassType> CreateAsync(ClassType entity);
        Task Update(ClassType currentEntity, ClassType newEntity);
        Task Remove(ClassType entity);
    }
}