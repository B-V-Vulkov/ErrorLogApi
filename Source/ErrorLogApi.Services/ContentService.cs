namespace ErrorLogApi.Services
{
    using System.Collections.Generic;

    using Contracts;
    using Models.Content;

    public class ContentService : IContentService
    {
        public IEnumerable<ApplicationServiceModel> GetApplicatins()
        {
            return new List<ApplicationServiceModel>()
            {
                new ApplicationServiceModel()
                {
                    Id = 1,
                    Name = "ClassBookApi"
                },
                new ApplicationServiceModel()
                {
                    Id = 2,
                    Name = "StudentsBookApi"
                }
            };
        }

        public IEnumerable<TimeDurationServiceModel> GetTimeDurationDropdown()
        {
            return new List<TimeDurationServiceModel>()
            {
                new TimeDurationServiceModel()
                {
                    Id = 1,
                    Name = "Today"
                },
                new TimeDurationServiceModel()
                {
                    Id = 2,
                    Name = "Last Week"
                },
                new TimeDurationServiceModel()
                {
                    Id = 3,
                    Name = "Last Month"
                },
                new TimeDurationServiceModel()
                {
                    Id = 4,
                    Name = "Last 6 Months"
                },
                new TimeDurationServiceModel()
                {
                    Id = 5,
                    Name = "Last Year"
                },
                new TimeDurationServiceModel()
                {
                    Id = 10,
                    Name = "All Time"
                }
            };
        }
    }
}
