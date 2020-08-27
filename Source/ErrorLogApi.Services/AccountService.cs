namespace ErrorLogApi.Services
{
    using System;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    using Data;
    using Data.Models;
    using Exceptions;
    using Security;
    using Contracts;
    using Models.Account;

    public class AccountService : IAccountService
    {
        private readonly IErrorLogDbContext dbContext;
        private readonly IJwtService jwtService;

        public AccountService(IErrorLogDbContext dbContext, IJwtService jwtService)
        {
            this.dbContext = dbContext;
            this.jwtService = jwtService;
        }

        public async Task<LoginResultServiceModel> AuthenticateAsync(LoginServiceModel model)
        {
            var filter = Builders<UserDataModel>.Filter
                .Eq(x => x.UserName, model.UserName);

            var user = await (await dbContext.UserCollection.FindAsync(filter))
                .FirstOrDefaultAsync();

            if (Object.Equals(user, null))
            {
                throw new InvalidUsernameOrPasswordException();
            }

            bool isValidPassword = PasswordHasher
                .VerifyHashedPassword(user.HashedPassword, model.Password);

            if (!isValidPassword)
            {
                throw new InvalidUsernameOrPasswordException();
            }

            var jwt = jwtService.GenerateJwt(user.UserName);

            return new LoginResultServiceModel()
            {
                UserName = user.UserName,
                Jwt = jwt
            };
        }
    }
}
