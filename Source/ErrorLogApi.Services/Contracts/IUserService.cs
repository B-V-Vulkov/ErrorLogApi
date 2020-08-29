namespace ErrorLogApi.Services.Contracts
{
    using System.Threading.Tasks;
    using Services.Models.User;

    public interface IUserService
    {
        Task<UserServiceModel> GetUserDataAsync(string username);
    }
}
