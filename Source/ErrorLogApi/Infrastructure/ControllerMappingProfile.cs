namespace ErrorLogApi.Infrastructure
{
    using AutoMapper;

    using RequestModels.Account;
    using Services.Models.Account;

    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<LoginRequestModel, LoginServiceModel>();
        }
    }
}
