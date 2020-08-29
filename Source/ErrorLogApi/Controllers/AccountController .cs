namespace ErrorLogApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;

    using Services.Contracts;
    using RequestModels.Account;
    using System;
    using ErrorLogApi.Security;
    using ResponseModels.Account;

    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;
        private readonly IUserService accountService;

        public AccountController(IMapper mapper, IJwtService jwtService, IUserService accountService)
        {
            this.mapper = mapper;
            this.jwtService = jwtService;
            this.accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseModels>> LoginAsync(LoginRequestModel request)
        {
            var response = new LoginResponseModels();

            var user = await this.accountService
                .GetUserDataAsync(request.Username);

            if (Object.Equals(user, null))
            {
                return Ok(response);
            }

            var isValidPassword = PasswordHasher
                .VerifyHashedPassword(user.Password, request.Password);

            if (!isValidPassword)
            {
                return Ok(response);
            }

            response.Status = true;
            response.Jwt = this.jwtService
                .GenerateJwt(request.Username);

            return Ok(response);
        }
    }
}
