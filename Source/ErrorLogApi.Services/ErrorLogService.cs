namespace ErrorLogApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Contracts;
    using Data;
    using ErrorLogApi.Data.Models;
    using ErrorLogApi.Services.Models.ErrorLog;
    using MongoDB.Driver;

    public class ErrorLogService : IErrorLogService
    {
        private readonly IErrorLogDbContext dbContext;
        private readonly IMapper mapper;

        public ErrorLogService(IErrorLogDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ErrorLogServiceModel> GetErrorLogAsync(Guid errorLogId)
        {
            var filter = Builders<ErrorLogDataModel>.Filter.Eq(x => x.Id, errorLogId);

            var errorLog = await (await dbContext.LogCollection.FindAsync(filter))
                .FirstOrDefaultAsync();

            return this.mapper.Map<ErrorLogServiceModel>(errorLog);
        }

        public async Task<IEnumerable<ErrorLogListingServiceModel>> GetErrorLogListAsync(int applicationId, int timeDurationId)
        {
            var today = DateTime.Today;

            var timeDuration = timeDurationId switch
            {
                1 => today,
                2 => today.AddDays(-7),
                3 => today.AddMonths(-1),
                4 => today.AddMonths(-6),
                5 => today.AddYears(-1),
                _ => DateTime.MinValue
            };

            var filter = Builders<ErrorLogDataModel>.Filter.Eq(x => x.ApplicationId, applicationId)
                & Builders<ErrorLogDataModel>.Filter.Gte(x => x.Date, timeDuration);

            var errorLogs = await (await dbContext.LogCollection.FindAsync(filter))
                .ToListAsync();

            return this.mapper.Map<IEnumerable<ErrorLogListingServiceModel>>(errorLogs);
        }

        public async Task<bool> InsertErrorLogAsync(InsertErrorLogServiceModel errorLog)
        {
            try
            {
                await dbContext.LogCollection.InsertOneAsync(this.mapper.Map<ErrorLogDataModel>(errorLog));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
