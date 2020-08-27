namespace ErrorLogApi.Data
{
    using MongoDB.Driver;

    using Models;

    public interface IErrorLogDbContext
    {
        IMongoCollection<UserDataModel> UserCollection { get; }
    }
}
