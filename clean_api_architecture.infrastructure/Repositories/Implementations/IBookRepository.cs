using clean_api_architecture.core.Entities;
using clean_api_architecture.infrastructure.Repositories.Abstractions;

namespace clean_api_architecture.infrastructure.Repositories.Implementations
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
