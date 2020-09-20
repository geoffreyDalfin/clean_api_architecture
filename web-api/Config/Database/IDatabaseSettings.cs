using System;
using MongoDB.Driver;

namespace web_api.Config.Database
{
    public interface IDatabaseSettings
    {
        MongoClient ConnectionString { get; }
        IMongoDatabase Database { get; set; }
    }
}