namespace ErrorLogApi.Services.Infrastructure
{
    using AutoMapper;

    using Data.Models;
    using Models.User;
    using Models.ErrorLog;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<UserDataModel, UserServiceModel>()
                .ForMember(x => x.Password, opts => opts.MapFrom(x => x.HashedPassword));

            this.CreateMap<ErrorLogDataModel, ErrorLogListingServiceModel>()
                .ForMember(x => x.ErrorLogId, opts => opts.MapFrom(x => x.Id));

            this.CreateMap<InsertErrorLogServiceModel, ErrorLogDataModel>();

            this.CreateMap<RequestHeaderServiceModel, RequestHeaderDataModel>();

            this.CreateMap<RequestHeaderDataModel, RequestHeaderServiceModel>();

            this.CreateMap<ErrorLogDataModel, ErrorLogServiceModel>();
        }
    }
}
