namespace ErrorLogApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Collections.Generic;
    using ErrorLogApi.Services.Models.Content;
    using ErrorLogApi.Services.Contracts;

    [Authorize]
    [ApiController]
    [Route("Content")]
    public class ContentController : ControllerBase
    {
        private readonly IContentService contentService;

        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet("GetApplications")]
        public ActionResult<IEnumerable<ApplicationServiceModel>> GetApplications()
            => Ok(this.contentService.GetApplicatins());







    }
}