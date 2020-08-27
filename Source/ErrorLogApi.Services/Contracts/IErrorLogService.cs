namespace ErrorLogApi.Services.Contracts
{
    using System.Threading.Tasks;

    using Models.ErrorLog;

    public interface IErrorLogService
    {
        Task InsertErrorLogAsync(ErrorLogServiceModel errorLog);
    }
}
