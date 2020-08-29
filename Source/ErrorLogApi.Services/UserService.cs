namespace ErrorLogApi.Services
{
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using AutoMapper;

    using Data;
    using Data.Models;
    using Contracts;
    using Models.User;

    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IErrorLogDbContext dbContext;

        public UserService(IErrorLogDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<UserServiceModel> GetUserDataAsync(string username)
        {
            var filter = Builders<UserDataModel>.Filter
                .Eq(x => x.Username, username);

            var user = await (await dbContext.UserCollection.FindAsync(filter))
                .FirstOrDefaultAsync();

            return this.mapper.Map<UserServiceModel>(user);
        }
    }
}
