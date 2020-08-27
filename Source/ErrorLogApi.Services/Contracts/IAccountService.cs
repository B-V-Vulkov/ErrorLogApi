namespace ErrorLogApi.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.Account;

    public interface IAccountService
    {
        Task<LoginResultServiceModel> AuthenticateAsync(LoginServiceModel requestModel);
    }
}
