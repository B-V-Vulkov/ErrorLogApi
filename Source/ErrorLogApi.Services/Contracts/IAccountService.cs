namespace ErrorLogApi.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.Account;

    public interface IAccountService
    {
        Task<UserServiceModel> GetUserDataAsync(string username);
    }
}
