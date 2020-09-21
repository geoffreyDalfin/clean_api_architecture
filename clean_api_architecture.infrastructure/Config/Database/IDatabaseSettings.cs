using System;
using MongoDB.Driver;

namespace clean_api_architecture.infrastructure.Config.Database
{
    public interface IDatabaseSettings
    {
        MongoClient ConnectionString { get; }
        IMongoDatabase Database { get; set; }
    }
}