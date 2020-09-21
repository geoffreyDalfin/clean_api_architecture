using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using clean_api_architecture.infrastructure.Repositories.Abstractions;
using clean_api_architecture.core.Entities;
using clean_api_architecture.infrastructure.Config.Database;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace clean_api_architecture.infrastructure.Repositories.Implementations
{
    public class BookRepository : RepoBase<Book>, IBookRepository
    {
        private const string collectionName = "books";
        private readonly ILogger<IBookRepository> _logger;

        public BookRepository(IDatabaseSettings settings, ILogger<IBookRepository> logger) : base(settings, collectionName)
        {
            this._logger = logger;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            await Context.InsertOneAsync(entity);
            return entity;
        }
        public IAsyncEnumerable<Book> FindAll()
        {
            FilterDefinition<Book> booksFilter = Builders<Book>.Filter.Empty;
            return this.GenericEnumerableFinderWithFilterDefinition(booksFilter);
        }
        public Task<Book> FindById(string id)
        {
            FilterDefinition<Book> bookFilter = Builders<Book>.Filter.Eq((book) => book.Id, id);
            return this.GenericFinderWithFilterDefinition(bookFilter);
        }
        public async Task Remove(Book entity)
        {
            FilterDefinition<Book> removeBookFilter = Builders<Book>.Filter.Eq((book) => book.Id, entity.Id);
            await Context.DeleteOneAsync(removeBookFilter);
        }
        public async Task Update(Book currentEntity, Book newEntity)
        {
            FilterDefinition<Book> findBookFilter = Builders<Book>.Filter.Eq((book) => book.Id, currentEntity.Id);
            await Context.FindOneAndReplaceAsync(findBookFilter, newEntity);
        }
    }
}