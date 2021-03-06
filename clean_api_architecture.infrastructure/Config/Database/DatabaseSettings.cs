using System;
using MongoDB.Driver;

namespace clean_api_architecture.infrastructure.Config.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        private readonly MongoClient connectionMode = new MongoClient("");
        private const string databaseName = "";
        MongoClient IDatabaseSettings.ConnectionString { get => connectionMode; }
        public IMongoDatabase Database { get; set; }

        public DatabaseSettings()
        {
            Database = this.connectionMode.GetDatabase(databaseName);
        }
    }
}