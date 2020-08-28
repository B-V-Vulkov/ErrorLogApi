namespace ErrorLogApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    using Services.Contracts;
    using Services.Models.Account;
    using RequestModels.Account;

    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel requestModel)
        {
            var user = await this.accountService.GetUserDataAsync(requestModel.Username);


            return Ok() 
        }
    }
}
