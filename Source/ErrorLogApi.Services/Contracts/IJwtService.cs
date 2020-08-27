namespace ErrorLogApi.Services.Contracts
{
    public interface IJwtService
    {
        string GenerateJwt(string userName);
    }
}
