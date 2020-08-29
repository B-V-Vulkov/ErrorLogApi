namespace ErrorLogApi.Services.Infrastructure
{
    using AutoMapper;

    using Data.Models;
    using ErrorLogApi.Services.Models.User;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<UserDataModel, UserServiceModel>()
                .ForMember(x => x.Password, opts => opts.MapFrom(x => x.HashedPassword));
        }
    }
}
