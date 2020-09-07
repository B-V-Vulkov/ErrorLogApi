namespace ErrorLogApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using AutoMapper;

    using Services.Contracts;
    using Services.Models.ErrorLog;
    using RequestModels.ErrorLog;

    [Authorize]
    [ApiController]
    [Route("ErrorLog")]
    public class ErrorLogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IErrorLogService errorLogService;

        public ErrorLogController(IMapper mapper, IErrorLogService errorLogService)
        {
            this.mapper = mapper;
            this.errorLogService = errorLogService;
        }

        [HttpPost("GetErrorLog")]
        public async Task<ActionResult<ErrorLogServiceModel>> GetErrorLogAsync(GetErrorLogRequestModel requestModel)
            => Ok(await this.errorLogService.GetErrorLogAsync(requestModel.ErrorLogId));

        [HttpPost("GetErrorLogList")]
        public async Task<ActionResult<ErrorLogListingServiceModel>> GetErrorLogListAsync(GetErrorLogListRequestModel requestModel)
            => Ok(await this.errorLogService.GetErrorLogListAsync(requestModel.ApplicationId, requestModel.TimeDurationId));

        [HttpPost("InsertErrorLog")]
        public async Task<IActionResult> InsertErrorLogAsync(InsertErrorLogRequestModel requestModel)
            => Ok(await this.errorLogService.InsertErrorLogAsync(this.mapper.Map<InsertErrorLogServiceModel>(requestModel)));
    }
}
