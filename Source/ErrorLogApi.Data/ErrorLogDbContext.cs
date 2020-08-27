namespace ErrorLogApi.Data
{
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    using Models;
    using GlobalConstants;

    public class ErrorLogDbContext : IErrorLogDbContext
    {
        private readonly IMongoDatabase database;

        private readonly DatabaseSettings databaseSettings;

        public ErrorLogDbContext(IOptions<ApplicationSettings> options)
        {
            this.databaseSettings = options.Value.Database;

            MongoClient client = new MongoClient(this.databaseSettings.ConnectionString);

            this.database = client.GetDatabase(this.databaseSettings.DatabaseName);

            this.UserCollection = database.GetCollection<UserDataModel>(this.databaseSettings.UserCollectionName);
            this.LogCollection = database.GetCollection<ErrorLogDataModel>(this.databaseSettings.LogCollectionName);
        }

        public IMongoCollection<UserDataModel> UserCollection { get; }

        public IMongoCollection<ErrorLogDataModel> LogCollection { get; }
    }
}
