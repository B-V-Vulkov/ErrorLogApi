namespace ErrorLogApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using AutoMapper;

    using Services.Contracts;
    using Services.Models.Account;
    using RequestModels.Account;

    [Authorize]
    [ApiController]
    [Route("ErrorLog")]
    public class ErrorLogController : ControllerBase
    {
        [HttpPost("GetAsync")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok("Aide!!!");
        }
    }
}
