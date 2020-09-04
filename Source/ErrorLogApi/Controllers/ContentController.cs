namespace ErrorLogApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Services.Contracts;
    using Services.Models.Content;

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


        [HttpGet("GetTimeDurationDropdown")]
        public ActionResult<IEnumerable<TimeDurationServiceModel>> GetTimeDurationDropdown()
            => Ok(this.contentService.GetTimeDurationDropdown());
    }
}
