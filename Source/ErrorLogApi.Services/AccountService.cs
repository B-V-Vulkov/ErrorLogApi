namespace ErrorLogApi.Services
{
    using System;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    using Data;
    using Data.Models;
    using Security;
    using Contracts;
    using Models.Account;
    using AutoMapper;

    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly IErrorLogDbContext dbContext;

        public AccountService(IErrorLogDbContext dbContext, IMapper mapper)
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

            var test=  this.mapper.Map<UserDataModel>(user);
        }
    }
}
