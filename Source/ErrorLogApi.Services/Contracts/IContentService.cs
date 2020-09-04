namespace ErrorLogApi.Services.Contracts
{
    using System.Collections.Generic;

    using Models.Content;

    public interface IContentService
    {
        IEnumerable<ApplicationServiceModel> GetApplicatins();
    }
}
