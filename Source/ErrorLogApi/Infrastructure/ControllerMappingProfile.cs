namespace ErrorLogApi.Infrastructure
{
    using AutoMapper;
    using ErrorLogApi.RequestModels.ErrorLog;
    using ErrorLogApi.Services.Models.ErrorLog;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<RequestHeaderRequestModel, RequestHeaderServiceModel>();

            this.CreateMap<InsertErrorLogRequestModel, InsertErrorLogServiceModel>()
                .ForMember(x => x.RequestHeaders, opts => opts.MapFrom(x => x.RequestHeaders));
        }
    }
}
