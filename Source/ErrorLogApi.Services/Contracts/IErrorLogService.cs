﻿namespace ErrorLogApi.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.ErrorLog;

    public interface IErrorLogService
    {
        Task<ErrorLogServiceModel> GetErrorLogAsync(Guid errorLogId);

        Task<IEnumerable<ErrorLogListingServiceModel>> GetErrorLogListAsync(int applicationId, int timeDurationId);

        Task<bool> InsertErrorLogAsync(InsertErrorLogServiceModel errorLog);
    }
}
