namespace ErrorLogApi.Services.Infrastructure
{
    using AutoMapper;
    using ErrorLogApi.Data.Models;
    using ErrorLogApi.Services.Models.Account;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<UserServiceModel, UserDataModel>();
        }
    }
}
