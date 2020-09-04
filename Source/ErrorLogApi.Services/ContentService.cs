using ErrorLogApi.Services.Contracts;
using ErrorLogApi.Services.Models.Content;
using System;
using System.Collections.Generic;

namespace ErrorLogApi.Services
{
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
            DateTime today = DateTime.Today;

            return new List<TimeDurationServiceModel>()
            {
                new TimeDurationServiceModel()
                {
                    Name = "Today",
                    StartDay = today,
                },
                new TimeDurationServiceModel()
                {
                    Name = "Last Week",
                    StartDay = today.AddDays(7),
                },
                new TimeDurationServiceModel()
                {
                    Name = "Last Month",
                    StartDay = today.AddMonths(1),
                },
                new TimeDurationServiceModel()
                {
                    Name = "Last 6 Months",
                    StartDay = today.AddMonths(6),
                },
                new TimeDurationServiceModel()
                {
                    Name = "Last Year",
                    StartDay = today.AddYears(1),
                },
                new TimeDurationServiceModel()
                {
                    Name = "All Time",
                    StartDay = DateTime.MinValue,
                }
            };
        }
    }
}
